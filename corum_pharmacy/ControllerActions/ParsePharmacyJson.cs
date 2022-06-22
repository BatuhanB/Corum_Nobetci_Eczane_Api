using corum_pharmacy.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace corum_pharmacy.ControllerActions
{
    public static class ParsePharmacyJson
    {
        public static List<Pharmacy> ParsePharmacy()
        {
            JsonSerializer _serializer = new JsonSerializer();
            var client = new RestClient("https://www.corumeo.org.tr/nobet-belediye/");//2022-06-22/2022-06-30
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            //result = result.Trim();
            //result.Replace(" ", string.Empty);
            string result = response.Content;
            string jsonStr = response.Content.Replace("\t", "").Replace(" {", "{");
            jsonStr = jsonStr.Substring(1, jsonStr.Length - 1);
            //Pharmacy empObj = JsonConvert.DeserializeObject<Pharmacy>(jsonStr);

            JObject jobject = (JObject)JsonConvert.DeserializeObject(jsonStr);
            List<Pharmacy> objects = new List<Pharmacy>();
            foreach (var item in jobject)
            {
                Pharmacy phar = JsonConvert.DeserializeObject<Pharmacy>(item.Value.ToString());
                objects.Add(phar);
            }
            return objects;

            //Pharmacy rootObj = JsonConvert.DeserializeObject<Pharmacy>(result);
            //string result2 = _serializer.Deserialize<Pharmacy>(rootObj);
            //var outObject = JsonConvert.DeserializeObject<Pharmacy>(result);
            //Console.WriteLine(response.Content);
        }

    }
}
