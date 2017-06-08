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
    public class RESTClientClient
    {
        private string baseUri = "http://localhost:50210/api/client/";

        public List<Client> getClients()
        {
            //want to access this link
            string uri = baseUri;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Client>>(response.Result);
            }           

        }

        public Client getClientById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Client>(response.Result);
            }
        }

        public bool PostClient(Client client)
        {
            string uri = baseUri;
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(client);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PostAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }

        public bool PutClient(Client client)
        {
            string uri = baseUri + client.Id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(client);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PutAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }

        public bool DeleteClient(int id)
        {
            string uri = baseUri + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = clientHTTP.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }
    }
}
