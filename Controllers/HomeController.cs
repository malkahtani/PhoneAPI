using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneAPI.Controllers
{
    public class HomeController : Controller
    {
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
        public ActionResult Departments()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Dep", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
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
        public ActionResult Ranks()
        {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Rank", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }
       
    }
}
