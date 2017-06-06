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

            return View(access.getReservation());
        }

        public ActionResult Details(int id)
        {
            AccessWebAPI access = new AccessWebAPI();

            return View(access.getReservationById(id));
        }

        public ActionResult Edit(int id)
        {
            AccessWebAPI access = new AccessWebAPI();
            Reservation reservation = access.getReservationById(id);
            return View(access.PutReservation(reservation));
        }

        public ActionResult Create()
        {
            AccessWebAPI access = new AccessWebAPI();

            ReservationVM rVM = new ReservationVM();
            rVM.Clients = access.getClients();
            rVM.Rooms = access.getRoom();

            return View(rVM);
        }

        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            AccessWebAPI access = new AccessWebAPI();

            access.PostReservation(reservation);

            

            return RedirectToAction("Index");
        }
    }
}