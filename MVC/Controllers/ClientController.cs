using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DTO;

namespace MVC.Controllers
{
    public class ClientController : Controller
    {

        RESTClientClient RESTClientClient = new RESTClientClient();

        // GET: Client
        public ActionResult Index()
        {
            return View(RESTClientClient.getClients());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            RESTClientClient.PostClient(client);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(RESTClientClient.getClientById(id));
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            RESTClientClient.PutClient(client);

            return RedirectToAction("index");
        }

        public ActionResult Delete(int id)
        {
            Client client = RESTClientClient.getClientById(id);

            return View(client);
        }

        [HttpPost]
        public ActionResult Delete(int id, string __RequestVerificationToken)
        {
            RESTClientClient.DeleteClient(id);

            return RedirectToAction("index");
        }
    }
}