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
    public class RESTRoomClient
    {

        private string baseUri = "http://localhost:50210/api/room/";

        public List<Room> GetRooms()
        {
            //want to access this link
            string uri = baseUri;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Room>>(response.Result);
            }

        }

        public Room getRoomById(int id)
        {
            string uri = baseUri + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<string> response = clientHTTP.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Room>(response.Result);
            }
        }

        public bool PostRoom(Room room)
        {
            string uri = baseUri;
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
            string uri = baseUri + room.Id;
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
            string uri = baseUri + id;
            using (HttpClient clientHTTP = new HttpClient())
            {
                Task<HttpResponseMessage> reponse = clientHTTP.DeleteAsync(uri);
                return reponse.Result.IsSuccessStatusCode;
            }
        }

    }
}