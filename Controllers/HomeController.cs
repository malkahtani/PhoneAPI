using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneAPI.Controllers
{
    public class HomeController : Controller
    {
        // Return the index page with the URI of the APIs
        public ActionResult Index()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Emp", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            string depUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Dep", });
            ViewBag.depUrl = new Uri(Request.Url, depUri).AbsoluteUri.ToString();

            string rankUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Rank", });
            ViewBag.rankUrl = new Uri(Request.Url, rankUri).AbsoluteUri.ToString();

            return View();
        }
        // Return the departments page with the URI of the Department API
        public ActionResult Departments()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Dep", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
        // Return the employees page with the URI of the APIs
        public ActionResult Employees()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Emp", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            string depUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Dep", });
            ViewBag.depUrl = new Uri(Request.Url, depUri).AbsoluteUri.ToString();

            string rankUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Rank", });
            ViewBag.rankUrl = new Uri(Request.Url, rankUri).AbsoluteUri.ToString();

            return View();
        }
        // Return the ranks page with the URI of the rank API
        public ActionResult Ranks()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Rank", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
       
    }
}
