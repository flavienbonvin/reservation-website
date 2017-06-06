using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BLL
{
    public class AccessWebAPI
    {
        private string baseUri = "http://localhost:2998/api/ProductsEF/";

        public List<Client> getClients()
        {
            //want to access this link
            string uri = baseUri;

            HttpClient clientHTTP = new HttpClient();
            //async is for access the link and do something else
            //new thread
            Task<string> response = clientHTTP.GetStringAsync(uri);
            clientHTTP.Dispose();
            return JsonConvert.DeserializeObject<List<Client>>(response.Result);

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

        /*
        public bool PutProducts(Product p)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(p);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = httpClient.PutAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }
        

        public bool DeleteProducts(int i)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = httpClient.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }
        */
    }
}
