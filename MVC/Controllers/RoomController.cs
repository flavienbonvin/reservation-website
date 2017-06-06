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

            return View(access.getRoom());
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
    }
}