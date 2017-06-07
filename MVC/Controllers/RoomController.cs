using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace MVC.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            AccessWebAPI access = new AccessWebAPI();

            return View(access.GetRooms());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            AccessWebAPI access = new AccessWebAPI();

            access.PostRoom(room);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            AccessWebAPI access = new AccessWebAPI();
            return View(access.getRoomById(id));
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            AccessWebAPI access = new AccessWebAPI();
            access.PutRoom(room);

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            AccessWebAPI access = new AccessWebAPI();
            Room room = access.getRoomById(id);

            return View(room);
        }

        [HttpPost]
        public ActionResult Delete(int id, string __RequestVerificationToken)
        {
            AccessWebAPI access = new AccessWebAPI();
            access.DeleteRoom(id);

            return RedirectToAction("index");
        }
    }
}