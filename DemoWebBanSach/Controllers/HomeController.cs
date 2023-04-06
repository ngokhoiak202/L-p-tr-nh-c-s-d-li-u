using DemoWebBanSach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoWebBanSach.Controllers
{
    public class HomeController : Controller
    {

        BANSACHEntities db = new BANSACHEntities();
        public ActionResult Index()
        {
            List<SACH> DSSACH = db.SACHes.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult login()
        {
            return View();
        }
    }
}