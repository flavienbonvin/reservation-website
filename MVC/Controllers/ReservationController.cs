using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;
using MVC.ViewModel;

namespace MVC.Controllers
{
    public class ReservationController : Controller
    {
        RESTReservationClient RESTReservationClient = new RESTReservationClient();

        // GET: Reservation
        public ActionResult Index()
        {
            return View(RESTReservationClient.getReservations());
        }

        public ActionResult Details(int id)
        {
            return View(RESTReservationClient.getReservationById(id));
        }

        public ActionResult Create()
        {
            RESTClientClient RESTClientClient = new RESTClientClient();
            RESTRoomClient RESTRoomClient = new RESTRoomClient();

            ReservationVM rVM = new ReservationVM();
            rVM.Clients = RESTClientClient.getClients();
            rVM.Rooms = RESTRoomClient.GetRooms();

            return View(rVM);
        }

        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            RESTClientClient RESTClientClient = new RESTClientClient();
            RESTRoomClient RESTRoomClient = new RESTRoomClient();

            reservation.Client = RESTClientClient.getClientById(reservation.Client.Id);
            reservation.Room = RESTRoomClient.getRoomById(reservation.Room.Id);

            RESTReservationClient.PostReservation(reservation);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            RESTClientClient RESTClientClient = new RESTClientClient();
            RESTRoomClient RESTRoomClient = new RESTRoomClient();

            ReservationVM rvm = new ReservationVM();
            rvm.Clients = RESTClientClient.getClients();
            rvm.Rooms = RESTRoomClient.GetRooms();
            rvm.reservation = RESTReservationClient.getReservationById(id);

            return View(rvm);
        }

        [HttpPost]
        public ActionResult Edit(Reservation reservation)
        {
            RESTClientClient RESTClientClient = new RESTClientClient();
            RESTRoomClient RESTRoomClient = new RESTRoomClient();

            reservation.Client = RESTClientClient.getClientById(reservation.Client.Id);
            reservation.Room = RESTRoomClient.getRoomById(reservation.Room.Id);

            RESTReservationClient.PutReservation(reservation);

            return RedirectToAction("index");
        }
        

        public ActionResult Delete(int id)
        {
            Reservation reservation = RESTReservationClient.getReservationById(id);

            return View(reservation);
        }

        [HttpPost]
        public ActionResult Delete(int id, string __RequestVerificationToken)
        {
            RESTReservationClient.DeleteReservation(id);

            return RedirectToAction("index");
        }
    }
}