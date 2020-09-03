using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventRegistration.Controllers
{
    public class RegisterController : Controller
    {
        private EventRegistrationDBEntities db = new EventRegistrationDBEntities();

        // GET: Event registration page.
        public ActionResult Index()
        {
            return View(db.Registers.ToList());
        }

        // GET: Event registration page.
        public ActionResult EventRegistration()
        {
            ViewBag.ConformationMessage = null;

            if (TempData.ContainsKey("Conformation"))
            {
                ViewBag.ConformationMessage = TempData["Conformation"].ToString();
            }

            // SelectList = table/model, data value field, data text field.
            ViewBag.Email = new SelectList(db.Clients, "Email", "Email");
            ViewBag.EventName = new SelectList(db.Events, "EventName", "EventName");

            return View();
        }

        // POST: Register client with an event page.
        [HttpPost]
        public ActionResult EventRegistration([Bind(Include = "Id,GuestNumber,PaymentAmount,EventName,Email")] Register register)
        {
            if (ModelState.IsValid)
            {
                db.Registers.Add(register);
                db.SaveChanges();
                
                if ( register.GuestNumber < 2)
                {
                    TempData["Conformation"] = register.Email + " has registered " + register.GuestNumber.ToString() + " person for the event " + register.EventName + ".";
                }

                if (register.GuestNumber > 1)
                {
                    TempData["Conformation"] = register.Email + " has registered " + register.GuestNumber.ToString() + " people for the event " + register.EventName + ".";
                }

                return RedirectToAction("EventRegistration");
            }
            
            ViewBag.Email = new SelectList(db.Clients, "Email", "Email", register.Email);
            ViewBag.EventName = new SelectList(db.Events, "EventName", "EventName", register.EventName);

            return View(register);
        }

        // GET: Search for an event registration page.
        public ActionResult SearchEventRegistration()
        {
            if (TempData.ContainsKey("alert"))
            {
                ViewBag.AlertMessage = TempData["alert"].ToString();
            }

            return View();
        }

        // GET: Search submit page
        public ActionResult SearchSubmit(string email, string eventName)
        {
            if ((eventName == null || eventName == "") && (email == null || email == ""))
            {
                TempData["alert"] = "Search box for event name and email cannot be empty!";
                return RedirectToAction("SearchEventRegistration");
            }
            else if (email == null || email == "")
            {
                TempData["alert"] = "Search box for email cannot be empty!";
                return RedirectToAction("SearchEventRegistration");
            }
            else if (eventName == null || eventName == "")
            {
                TempData["alert"] = "Search box for event name cannot be empty!";
                return RedirectToAction("SearchEventRegistration");
            }

            var recordToDelete = db.Registers.Where(x =>((x.Email.Contains(email)) && (x.EventName.Contains(eventName))));

            if (!recordToDelete.Any())
            {
                return View();
            }
            else
            {
                return RedirectToAction("DeleteEventRegistration", new { email, eventName });
            }
        }

        // GET: Display registered event details page.
        public ActionResult DeleteEventRegistration(string email, string eventName)
        {
            var recordToDelete = db.Registers.Where(x => x.Email == email && x.EventName == eventName);
            Register register = recordToDelete.First();

            return View(register);
        }

        // POST: Delete selected registration.
        [HttpPost, ActionName("DeleteEventRegistration")]
        public ActionResult DeleteRegistration(string email, string eventName)
        {
            var recordToDelete = db.Registers.Where(x => x.Email == email && x.EventName == eventName);
            Register register = recordToDelete.First();

            db.Registers.Remove(register);
            db.SaveChanges();

            TempData["alert"] = "Event registration has been deleted. You will be refunded $" + register.PaymentAmount;

            return RedirectToAction("SearchEventRegistration");
        }
    }
}