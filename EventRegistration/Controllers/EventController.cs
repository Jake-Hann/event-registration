using EventRegistration.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EventRegistration.Controllers
{
    public class EventController : Controller
    {
        private EventRegistrationDBEntities db = new EventRegistrationDBEntities();

        // GET: Display events page.
        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        // GET: Search client page.
        public ActionResult SearchEvent()
        {
            if (TempData.ContainsKey("alert"))
            {
                ViewBag.AlertMessage = TempData["alert"].ToString();
            }

            return View();
        }

        // GET: Search submit page.
        public ActionResult SearchSubmit(string keyword)
        {
            if (keyword == null || keyword == "")
            {
                TempData["alert"] = "Search box cannot be empty!";
                return RedirectToAction("SearchEvent");
            }

            var eventQuery = db.Events.Where(x => x.EventName.Contains(keyword) || x.Date.Contains(keyword));
            var foundEvents = eventQuery.ToList();

            if (foundEvents.Any())
            {
                TempData["searchResults"] = foundEvents;
                return RedirectToAction("EventSearchResults");
            }

            return View();
        }

        // GET: Search results page.
        public ActionResult EventSearchResults()
        {
            var searchResults = TempData["searchResults"];
            return View(searchResults);
        }
    }
}