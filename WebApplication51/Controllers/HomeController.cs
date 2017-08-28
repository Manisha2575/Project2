using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication51.Models;

namespace WebApplication51.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

     /*   public ActionResult GetData()
        {
            using (Context db = new Context())
            {
                var EmoloyeeData = db.studentes.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = EmoloyeeData }, JsonRequestBehavior.AllowGet);
            }
        }*/

    }
}