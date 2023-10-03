using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestrauntP
{
    public class Company
    {
        public int RANK { get; set; }
        public string LOGO { get; set; }
        public string COMPANY { get; set; }
        public string CATEGORY { get; set; }

        [JsonProperty("2018 US SYSTEMWIDE SALES MILLIONS")]
        public double SALES_MILLIONS_2018_US { get; set; }

        public Company()
        {
            RANK = 0;
            LOGO = string.Empty;
            COMPANY = string.Empty;
            CATEGORY = string.Empty;
            SALES_MILLIONS_2018_US = 0;
        }

        public override string ToString()
        {
            return $"{COMPANY}";
        }
    }
        
    
}
