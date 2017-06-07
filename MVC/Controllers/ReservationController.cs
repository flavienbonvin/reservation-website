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
        // GET: Reservation
        public ActionResult Index()
        {
            AccessWebAPI access = new AccessWebAPI();

            return View(access.getReservations());
        }

        public ActionResult Details(int id)
        {
            AccessWebAPI access = new AccessWebAPI();

            return View(access.getReservationById(id));
        }

        public ActionResult Create()
        {
            AccessWebAPI access = new AccessWebAPI();

            ReservationVM rVM = new ReservationVM();
            rVM.Clients = access.getClients();
            rVM.Rooms = access.GetRooms();

            return View(rVM);
        }

        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            AccessWebAPI access = new AccessWebAPI();

            reservation.Client = access.getClientById(reservation.Client.Id);
            reservation.Room = access.getRoomById(reservation.Room.Id);

            access.PostReservation(reservation);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            AccessWebAPI access = new AccessWebAPI();

            ReservationVM rvm = new ReservationVM();
            rvm.Clients = access.getClients();
            rvm.Rooms = access.GetRooms();
            rvm.reservation = access.getReservationById(id);

            return View(rvm);
        }

        [HttpPost]
        public ActionResult Edit(Reservation reservation)
        {
            AccessWebAPI access = new AccessWebAPI();

            reservation.Client = access.getClientById(reservation.Client.Id);
            reservation.Room = access.getRoomById(reservation.Room.Id);

            access.PutReservation(reservation);

            return RedirectToAction("index");
        }
        

        public ActionResult Delete(int id)
        {
            AccessWebAPI access = new AccessWebAPI();
            Reservation reservation = access.getReservationById(id);

            return View(reservation);
        }

        [HttpPost]
        public ActionResult Delete(int id, string __RequestVerificationToken)
        {
            AccessWebAPI access = new AccessWebAPI();
            access.DeleteReservation(id);

            return RedirectToAction("index");
        }
    }
}