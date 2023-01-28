using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strava_cz_bruteforce_default_login
{
    public class CanteenListItem
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public string DisplayMember => $"{Id} - {Name}";
    }
}
