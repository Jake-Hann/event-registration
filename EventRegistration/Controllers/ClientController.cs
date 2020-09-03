using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventRegistration.Controllers
{
    public class ClientController : Controller
    {
        private EventRegistrationDBEntities db = new EventRegistrationDBEntities();

        // GET: Display all clients page
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Register new client page
        public ActionResult ClientRegistration()
        {
            ViewBag.ConformationMessage = null;
            return View();
        }

        // POST: Validation/Register new client
        [HttpPost]
        public ActionResult ClientRegistration([Bind(Include = "Email,FullName,Address,Age,Phone")] Client client)
        {
            Client c = db.Clients.Find(client.Email);

            if ( c != null)
            {
                ViewBag.ConformationMessage = "Account for " + client.Email + " already exists! Please enter a different email.";
                return View(client);
            }

            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                ViewBag.ConformationMessage = "Client registration for " + client.FullName + " was successful!";
            }

            return View();
        }

        // GET: Search client page
        public ActionResult SearchClient()
        {
            if (TempData.ContainsKey("alert"))
            {
                ViewBag.AlertMessage = TempData["alert"].ToString();
            }

            return View();
        }

        // GET: Search submit page
        public ActionResult SearchSubmit(string email)
        {
            if (email == null || email == "")
            {
                TempData["alert"] = "Please enter an email address...";
                return RedirectToAction("SearchClient");
            }

            Client client = db.Clients.Find(email);

            if (client == null)
            {
                return View();
            }
                
            return RedirectToAction("ClientDetails", new { email });
        }

        // GET: Display client details page
        public ActionResult ClientDetails(string email)
        {
            Client client = db.Clients.Find(email);
            return View(client);
        }

        // GET: Edit client details page
        public ActionResult EditClient(string email)
        {
            Client client = db.Clients.Find(email);
            return View(client);
        }

        // POST: Save edited client details.
        [HttpPost]
        public ActionResult EditClient(string email, string address, string phone)
        {
            Client client = db.Clients.Find(email);

            if (address != null && phone != null && address != "" && phone != "")
            {
                client.Address = address;
                client.Phone = phone;
                db.SaveChanges();

                client = db.Clients.Find(email);

                return RedirectToAction("EditClientConformation", new { email });
            }
            else
            {
                return RedirectToAction("EditClient", client);
            }
        }

        // GET: Edit client conformation
        public ActionResult EditClientConformation(string email)
        {
            Client client = db.Clients.Find(email);
            return View(client);
        }

        // GET: Delete client page
        public ActionResult DeleteClient(string email)
        {
            Client client = db.Clients.Find(email);
            return View(client);
        }

        // POST: Delete selected client
        [HttpPost, ActionName("DeleteClient")]
        public ActionResult DeleteConfirmed(string email)
        {
            Client client = db.Clients.Find(email);
            db.Clients.Remove(client);
            db.SaveChanges();

            return RedirectToAction("DeleteClientConformation");
        }

        // GET: Delete client conformation page
        public ActionResult DeleteClientConformation(string email)
        {
            return View();
        } 
    }
}