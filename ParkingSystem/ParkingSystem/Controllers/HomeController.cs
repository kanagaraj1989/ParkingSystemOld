using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParkingSystem.Models;

namespace ParkingSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (ParkingEntities db = new ParkingEntities())
                {
                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        Session["UserType"] = obj.UserType.ToString();
                        if (obj.UserType == 1)
                        {
                            
                           // model.parkingGate = parkingGateList;
                            return RedirectToAction("AdminUserDashBoard");
                        }
                        else if(obj.UserType == 2)
                        {
                            return RedirectToAction("EntryGate", "Parking");
                        }
                        else if (obj.UserType == 3)
                        {
                            return RedirectToAction("OutGate", "Parking");
                        }
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult AdminUserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                var parkingGateList = new List<SelectListItem>();
                parkingGateList.Add(new SelectListItem
                {
                    Text = "Entry Gate",
                    Value = "2",
                    Selected = true
                });
                parkingGateList.Add(new SelectListItem
                {
                    Text = "Out Gate",
                    Value = "3"
                });
                ViewData["GateList"] = parkingGateList;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout() {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult CreateGate(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (ParkingEntities db = new ParkingEntities())
                {
                    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj == null)
                    {
                        objUser.IsActive = true;
                        db.UserProfiles.Add(objUser);
                        db.SaveChanges();
                        return RedirectToAction("AdminUserDashBoard");
                    }
                }
            }
            return View(objUser);
        }
    }
}