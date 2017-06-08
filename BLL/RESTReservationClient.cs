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
    public class RESTReservationClient
    {
        private string baseUri = "http://localhost:50210/api/reservation/";

        public List<Reservation> getReservations()
        {
            //want to access this link
            string uri = baseUri;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Reservation>>(response.Result);
            }

        }

        public Reservation getReservationById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Reservation>(response.Result);
            }
        }

        public bool PostReservation(Reservation reservation)
        {
            string uri = baseUri;
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(reservation);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PostAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }

        public bool PutReservation(Reservation reservation)
        {
            string uri = baseUri + reservation.Id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(reservation);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PutAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteReservation(int id)
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
