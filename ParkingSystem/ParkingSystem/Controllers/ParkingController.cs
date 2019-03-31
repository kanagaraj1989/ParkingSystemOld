using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParkingSystem.Controllers
{
    public class ParkingController : Controller
    {
        // GET: Parking
        public ActionResult EntryGate()
        {
            return View();
        }

        public ActionResult OutGate()
        {
            return View();
        }
    }
}