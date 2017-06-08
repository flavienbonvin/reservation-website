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

        RESTRoomClient RESTRoomClient = new RESTRoomClient();

        // GET: Room
        public ActionResult Index()
        {
            return View(RESTRoomClient.GetRooms());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            RESTRoomClient.PostRoom(room);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(RESTRoomClient.getRoomById(id));
        }

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            RESTRoomClient.PutRoom(room);

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Room room = RESTRoomClient.getRoomById(id);

            return View(room);
        }

        [HttpPost]
        public ActionResult Delete(int id, string __RequestVerificationToken)
        {
            RESTRoomClient.DeleteRoom(id);

            return RedirectToAction("index");
        }
    }
}