using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yazilim.Entities.Northwind
{
   public class WebApiTable:Attribute
    {
        public string TableName { get; set; }
        public string Key { get; set; }
        public string SubTable { get; set; }

    }
}
