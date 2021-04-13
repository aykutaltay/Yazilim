using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Yazilim.Entities;
using Yazilim.Entities.Northwind;


namespace Yazilim.Core.WebApi
{
    public static class NorthwindApiServices
    {
        private const string URL = "https://northwind.vercel.app/api/";

        public static ApiResponse WebApList<T>() where T : class
        {
            ApiResponse result = new ApiResponse();
            Type type = typeof(T);

            var attr = type.GetCustomAttributes(typeof(WebApiTable), false);

            if (attr == null || !attr.Any())
            {
                return result;

            }

            //birden fazla olduğunda burası değişebilir
            WebApiTable webApiTable = attr[0] as WebApiTable;

            string urlTableName = URL + webApiTable.TableName;

            var client = new RestClient(urlTableName);
            var request = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            var response = client.Execute(request);
            result.IsSuccessful = response.IsSuccessful;
            if (response.IsSuccessful)
            {
                result.Content = response.Content;
                DbLogger.LogDb("WEB APİ ÇAĞRISI", result, webApiTable.TableName, Core.Enums.eLogType.APIGET);
            }
            else
            {

                DbLogger.LogDb("WEB APİ ÇAĞRISI HATASI ", response.Content, webApiTable.TableName, Core.Enums.eLogType.APIGET_ERROR);
            }


            return result;

        }

        public static ApiResponse Post<T>(T entity) where T : class, new()
        {

            ApiResponse result = new ApiResponse();
            Type type = typeof(T);

            var attr = type.GetCustomAttributes(typeof(WebApiTable), false);

            if (attr == null || !attr.Any())
            {
                result.IsSuccessful = false;
                result.Content = "Model Başlıkları Tanımlanmamış";
                return result;

            }

            WebApiTable webApiTable = attr[0] as WebApiTable;

            string urlTableName = URL + webApiTable.TableName;

            var client = new RestClient(urlTableName);
            var request = new RestRequest(Method.POST);


            var entityJson = JsonConvert.SerializeObject(entity);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entityJson);

            IRestResponse response = client.Execute(request);

            result.IsSuccessful = response.IsSuccessful;
            if (response.IsSuccessful)
            {

                response.Content = entityJson;
                DbLogger.LogDb("WEB APİ POST ÇAĞRISI", entityJson, webApiTable.TableName, Core.Enums.eLogType.APIPOST);
            }
            else
            {
                response.Content = response.Content;
                DbLogger.LogDb("WEB APİ POST ÇAĞRISI HATASI ", response.Content, webApiTable.TableName, Core.Enums.eLogType.APIPOST_ERROR);
            }


            return result;
        }


        public static ApiResponse Delete<T>(T entity) where T : class, new()
        {

            ApiResponse result = new ApiResponse();
            Type type = typeof(T);

            var attr = type.GetCustomAttributes(typeof(WebApiTable), false);

            if (attr == null || !attr.Any())
            {
                result.IsSuccessful = false;
                result.Content = "Model Başlıkları Tanımlanmamış";
                return result;

            }





            WebApiTable webApiTable = attr[0] as WebApiTable;



            Type t = entity.GetType();

            PropertyInfo[] props = t.GetProperties();

            string IdentityValue = "";

            //key değerini almak için eklendi
            IdentityValue = props.Where(w => w.Name == webApiTable.Key).Select(q => q.GetValue(entity)).First().ToString();




            string urlTableName = URL + webApiTable.TableName + "/" + IdentityValue;

            var client = new RestClient(urlTableName);
            var request = new RestRequest(Method.DELETE);


            var entityJson = JsonConvert.SerializeObject(entity);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entityJson);

            IRestResponse response = client.Execute(request);

            result.IsSuccessful = response.IsSuccessful;
            if (response.IsSuccessful)
            {

                response.Content = entityJson;
                DbLogger.LogDb("WEB APİ Delete ÇAĞRISI", entityJson, webApiTable.TableName, Core.Enums.eLogType.APIDELETE);
            }
            else
            {
                response.Content = response.Content;
                DbLogger.LogDb("WEB APİ Delete ÇAĞRISI HATASI ", response.Content, webApiTable.TableName, Core.Enums.eLogType.APIDELETE_ERROR);
            }


            return result;
        }


        public static ApiResponse PUT<T>(T entity) where T : class, new()
        {

            ApiResponse result = new ApiResponse();
            Type type = typeof(T);

            var attr = type.GetCustomAttributes(typeof(WebApiTable), false);

            if (attr == null || !attr.Any())
            {
                result.IsSuccessful = false;
                result.Content = "Model Başlıkları Tanımlanmamış";
                return result;

            }





            WebApiTable webApiTable = attr[0] as WebApiTable;



            Type t = entity.GetType();

            PropertyInfo[] props = t.GetProperties();

            string IdentityValue = "";

            //key değerini almak için eklendi
            IdentityValue = props.Where(w => w.Name == webApiTable.Key).Select(q => q.GetValue(entity)).First().ToString();




            string urlTableName = URL + webApiTable.TableName + "/" + IdentityValue;

            var client = new RestClient(urlTableName);
            var request = new RestRequest(Method.PUT);


            var entityJson = JsonConvert.SerializeObject(entity);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(entityJson);

            IRestResponse response = client.Execute(request);

            result.IsSuccessful = response.IsSuccessful;
            if (response.IsSuccessful)
            {

                response.Content = entityJson;
                DbLogger.LogDb("WEB APİ Delete ÇAĞRISI", entityJson, webApiTable.TableName, Core.Enums.eLogType.APIPUT);
            }
            else
            {
                response.Content = response.Content;
                DbLogger.LogDb("WEB APİ Delete ÇAĞRISI HATASI ", response.Content, webApiTable.TableName, Core.Enums.eLogType.APIPUT_ERROR);
            }


            return result;
        }
    }
}
