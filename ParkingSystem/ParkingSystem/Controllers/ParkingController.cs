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
        public ActionResult EntryGate(ParkingLog parkingLog)
        {
            return View(parkingLog);
        }

        public ActionResult OutGate()
        {
            return View();
        }
    }
}