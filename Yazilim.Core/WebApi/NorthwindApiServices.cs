using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Yazilim.Entities.Northwind;

namespace Yazilim.Core.WebApi
{
    public static class NorthwindApiServices
    {
        private const string URL = "https://northwind.now.sh/api/";







        public static  IEnumerable<T> WebApListAsync<T>() where T : class
        {
            IEnumerable<T> result = null;
            Type type = typeof(T);

            var attr = type.GetCustomAttributes(typeof(WebApiTable), false);

            if (attr == null || !attr.Any())
            {
                return result;

            }

            //birden fazla olduğunda burası değişebilir
            WebApiTable webApiTable = attr[0] as WebApiTable;

            string urlTableName = URL + webApiTable.TableName;



            //tekrar bakılacak
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(urlTableName).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    var respostr = responseContent.ReadAsStringAsync().GetAwaiter().GetResult();

                    result = JsonConvert.DeserializeObject<List<T>>(respostr);
                    DbLogger.LogDb("Web Çağrısı", respostr, webApiTable.TableName, Core.Enums.eLogType.WebGetAll);
                }
            }











            return result;

        }


    }
}
