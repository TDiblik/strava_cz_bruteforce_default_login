using HtmlAgilityPack;
using RestSharp;
using System.Web;
using System.Xml;

namespace strava_cz_bruteforce_default_login
{
    public partial class MainForm : Form
    {
        private const string canteen_list_url = "https://www.strava.cz/Strava/Stravnik/Zarizeni";

        private const string canteens_savefile_name = "canteens.txt";
        private const string canteen_id_name_separator = ";-=-;";

        public MainForm()
        {
            InitializeComponent();

            CanteenList.DisplayMember = nameof(CanteenListItem.DisplayMember);
            CanteenList.ValueMember = nameof(CanteenListItem.Id);

            load_canteens_from_savefile();
        }

        private static string xpath_div_contains_class(string class_name) => $".//div[contains(concat(' ', normalize-space(@class), ' '), ' {class_name} ')]";
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
                    Id = canteen_info[0],
                    Name = canteen_info[1]
                });
            }

            CanteenList.Items.AddRange(available_canteens_formatted.OrderBy(s => s.Id).ToArray());
        }
    }
}