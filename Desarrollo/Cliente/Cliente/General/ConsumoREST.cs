using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using RestSharp;
using System.Data;
using Newtonsoft.Json;


namespace Cliente.General
{
    public class ConsumoREST
    {

        private static readonly HttpClient client = new HttpClient();

        public DataTable consultar(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest("", Method.GET);
            
            IRestResponse response2 = client.Execute(request);

            var data = response2.Content;

            DataTable dt = (DataTable)JsonConvert.DeserializeObject(data, (typeof(DataTable)));

            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
            {
            }
            return dt;
        }

        public string registrar(string url, string estu_id, string id, string pnombre, string snombre, string papellido, string sapellido, string correo)
        {
            var client = new RestClient(url);
            var request = new RestRequest("", Method.POST);

            request.AddHeader("Content-type", "application/x-www-form-urlencoded");

            request.AddParameter("ESTU_ID", estu_id);
            request.AddParameter("identificacion", id);
            request.AddParameter("Pnombre", pnombre);
            request.AddParameter("Snombre", snombre);
            request.AddParameter("Papellido", papellido);
            request.AddParameter("Sapellido", sapellido);
            request.AddParameter("correo", correo);

            
            IRestResponse response2 = client.Execute(request);
            var data = response2.Content;

            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
            {
            }

            string dt = (string)JsonConvert.DeserializeObject(data, (typeof(string)));
            return dt;
        }
    }
    public class ResponseData
    {
        #region variables de error
        public string type { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        #endregion

        // { access_token: "1fhd0yu7i7kq0r4ds5w8ri6s3pzx0uqw0li…", token_type: "Bearer", expires_in: "604800", refresh_token: "ei6gq9wdn8uru35q4qp6t6j3w0fh48y09eh…", state: "xyz", scope: "[{"APELLIDOS":"MORA RAMOS","NOMBRES…" }
        #region variables de respuesta valida
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
        #endregion

        public ResponseData() { }
    }
}