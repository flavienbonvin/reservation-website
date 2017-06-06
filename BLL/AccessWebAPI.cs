using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccessWebAPI
    {
        private string baseUri = "http://localhost:50210/api/";

        public List<Client> getClients()
        {
            //want to access this link
            string uri = baseUri + "client";
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Client>>(response.Result);
            }           

        }

        public bool PostClient(Client client)
        {
            string uri = baseUri + "client";
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(client);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PostAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }

        public bool PutProducts(Client client)
        {
            string uri = baseUri + "client";
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(client);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PutAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }
        
        
        public bool DeleteProducts(int i)
        {
            string uri = baseUri + "client";
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = clientHTTP.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }
        
    }
}
