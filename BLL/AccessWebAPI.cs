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

        //----------------------------------CLIENT------------------------------------------

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

        public Client getClientById(int id)
        {
            string uri = baseUri + "client/" + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Client>(response.Result);
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

        public bool PutClient(Client client)
        {
            string uri = baseUri + "client/" + client.Id;
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
            string uri = baseUri + "client/" + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = clientHTTP.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }

        //----------------------------------ROOM------------------------------------------

        public List<Room> GetRooms()
        {
            //want to access this link
            string uri = baseUri + "room";
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Room>>(response.Result);
            }

        }

        public Room getRoomById(int id)
        {
            string uri = baseUri + "room/" + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Room>(response.Result);
            }
        }

        public bool PostRoom(Room room)
        {
            string uri = baseUri + "room";
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(room);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PostAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }

        }

        public bool PutRoom(Room room)
        {
            string uri = baseUri + "room/" + room.Id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(room);
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> reponse = clientHTTP.PutAsync(uri, frame);
                return reponse.Result.IsSuccessStatusCode;
            }
        }

        public bool DeleteRoom(int id)
        {
            string uri = baseUri + "room/" + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = clientHTTP.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }


        //----------------------------------RESERVATION------------------------------------------

        public List<Reservation> getReservations()
        {
            //want to access this link
            string uri = baseUri + "reservation";
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Reservation>>(response.Result);
            }

        }

        public Reservation getReservationById(int id)
        {
            string uri = baseUri + "reservation/" + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Reservation>(response.Result);
            }
        }

        public bool PostReservation(Reservation reservation)
        {
            string uri = baseUri + "reservation";
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
            string uri = baseUri + "reservation/" + reservation.Id;
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
            string uri = baseUri + "reservation/" + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = clientHTTP.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }

    }

}
