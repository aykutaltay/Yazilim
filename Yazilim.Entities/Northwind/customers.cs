using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Entities.Northwind
{

    //Reflection ile başlık bilgileri alınacak
    [WebApiTable(TableName = "customers", Key = "Id", SubTable = "Address")]
    public class Customers
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("contactName")]
        public string ContactName { get; set; }

        [JsonProperty("contactTitle")]
        public string ContactTitle { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

}
