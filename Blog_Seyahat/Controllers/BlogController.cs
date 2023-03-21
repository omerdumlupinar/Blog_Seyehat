using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_Seyahat.Models.Sınıflar;

namespace Blog_Seyahat.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var degerler = c.GetBlogs.ToList();
            by.Deger1 = c.GetBlogs.OrderByDescending(x => x.ID).ToList();
            //sondan 2 Blogu Çekmek için
            by.Deger3 = c.GetBlogs.OrderByDescending(x => x.ID).Take(7).ToList();
            by.Deger2 = c.Yorumlars.OrderByDescending(x => x.ID).Take(7).ToList();
            return View(by);
        }

        
        public ActionResult BlogDetay(int id)
        {
            //var degerler = c.GetBlogs.Where(x => x.ID == id).ToList();
            by.Deger1 = c.GetBlogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
    }
}