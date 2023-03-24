using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_Seyahat.Models.Sınıflar;  

namespace Blog_Seyahat.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.GetBlogs.OrderByDescending(x=>x.ID).ToList();
            return View(degerler);
        }

        public PartialViewResult partial1()
        {

            var deger = c.GetBlogs.OrderByDescending(z => z.ID).Take(3).ToList();

            return PartialView(deger);   
        }
        public PartialViewResult partial2()
        {

            var degerler = c.GetBlogs.OrderByDescending(x=>x.ID).Take(10).ToList();
            
            
            return PartialView(degerler);
        }


        public PartialViewResult partial3()
        {

            var degerler = c.GetBlogs.OrderByDescending(x => x.ID).Take(5).ToList();


            return PartialView(degerler);
        }

        public PartialViewResult partial4()
        {

            var degerler = c.Yorumlars.OrderByDescending(x => x.ID).Take(5).ToList();


            return PartialView(degerler);
        }
    }
}