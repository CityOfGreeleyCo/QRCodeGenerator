using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QR_Code_Generator.Models;

namespace QR_Code_Generator.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var codes = new Codes();
            return View(codes);
        }

        [HttpPost]
        public ActionResult Detail(Codes code)
        {
            return View(code);

        }
    }
}
