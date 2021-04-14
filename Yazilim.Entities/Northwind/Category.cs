using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Entities.Northwind
{

    //Reflection ile başlık bilgileri alınacak
    [WebApiTable(TableName = "categories", Key = "Id")]
    public class Category
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
