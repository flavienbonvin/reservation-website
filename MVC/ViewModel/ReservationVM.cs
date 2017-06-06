using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO;
using System.Collections;

namespace MVC.ViewModel
{
    public class ReservationVM
    {
        public Reservation reservation { get; set;}

        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Client> Clients { get; set; }

        public List<int> selectedIds { get; set; }

    }
}