using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Entities.Northwind
{

    //Reflection ile api  çelilecek
    [WebApiTable(TableName = "categories", Key = "id")]
    public class categories
    {
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }

    }
}
