using corum_pharmacy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;

namespace corum_pharmacy.ControllerActions
{
    public static class ParseTownJson
    {
        public static List<Town> ParseTown()
        {
            var client = new RestClient("https://www.corumeo.org.tr/corum-ilceler");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            string result = response.Content;
            string jsonStr = response.Content.Replace("\t", "").Replace(" {", "{");
            jsonStr = jsonStr.Substring(1, jsonStr.Length - 1);

            JObject jobject = (JObject)JsonConvert.DeserializeObject(jsonStr);
            List<Town> objects = new List<Town>();
            foreach (var item in jobject)
            {
                Town town = JsonConvert.DeserializeObject<Town>(item.Value.ToString());
                objects.Add(town);
            }
            return objects;
            //Console.WriteLine(response.Content);
        }
    }
}
