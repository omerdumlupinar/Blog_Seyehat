using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_Seyahat.Models.Sınıflar;

namespace Blog_Seyahat.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        Context c = new Context();
        public ActionResult Index()
        {
            var bilgiler = c.AdresBlogs.ToList();

            return View(bilgiler);
        }


        [HttpGet]
        public PartialViewResult iletisimForm()
        {
            return PartialView();
        }



        [HttpPost]
        public PartialViewResult iletisimForm(iletisim i)
        {
            c.İletisims.Add(i);
            c.SaveChanges();
            return PartialView();
        }
    }
}