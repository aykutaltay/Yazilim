using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Entities.Northwind
{

    //Reflection ile başlık bilgileri alınacak
    [WebApiTable(TableName = "products", Key = "Id")]
    public  class Products
    {

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("supplierId")]
        public long SupplierId { get; set; }

        [JsonProperty("categoryId")]
        public long CategoryId { get; set; }

        [JsonProperty("quantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [JsonProperty("unitPrice")]
        public long UnitPrice { get; set; }

        [JsonProperty("unitsInStock")]
        public long UnitsInStock { get; set; }

        [JsonProperty("unitsOnOrder")]
        public long UnitsOnOrder { get; set; }

        [JsonProperty("reorderLevel")]
        public long ReorderLevel { get; set; }

        [JsonProperty("discontinued")]
        public bool Discontinued { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("supplier")]
        public Supplier Supplier { get; set; }

        [JsonProperty("category")]
        public Category Category { get; set; }

    }
}
