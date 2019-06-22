using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using SCB.Models;
using Newtonsoft.Json;

namespace SCB
{
    public class DataConfig
    {
        private readonly string WEB_URL = "http://api.scb.se/OV0104/v1/doris/sv/ssd/BE/BE0101/BE0101G/Befforandr";
        private readonly HttpClient Client = new HttpClient();

        public void DownloadData()
        {
            // Our data is static and readonly, so we download it once on app start up.
            GetFields();
            getData();
            
        }

        private StringContent LoadPostRequest()
        {
            StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/request.json"));
            string contents = reader.ReadToEnd();
            reader.Close();
            return new StringContent(contents, Encoding.UTF8, "application/json");
        }
        private void GetFields()
        {
            HttpResponseMessage result = Client.GetAsync(WEB_URL).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                StreamWriter writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/fields.json"));
                string json = result.Content.ReadAsStringAsync().Result;
                Data.rawMetaData = JsonConvert.DeserializeObject<RawMetaData>(json);
                writer.Write(json);
                writer.Close();
            }
            else
            {

            }

        }

        private void getData()
        {
            HttpResponseMessage result = Client.PostAsync(WEB_URL, LoadPostRequest()).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                StreamWriter writer = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/data.json"));
                string json = result.Content.ReadAsStringAsync().Result;
                Data.SetData(JsonConvert.DeserializeObject<RawData>(json));
                writer.Write(json);
                writer.Close();
            }
            else
            {

            }
        }
    }
}