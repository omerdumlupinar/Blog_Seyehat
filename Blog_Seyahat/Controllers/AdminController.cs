using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_Seyahat.Models.Sınıflar;

namespace Blog_Seyahat.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.GetBlogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog( Blog b)
        {
            c.GetBlogs.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult BlogSil(int id)
        {
            var idbul = c.GetBlogs.Find(id);
            c.GetBlogs.Remove(idbul);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bGetir = c.GetBlogs.Find(id);     
            return View("BlogGetir", bGetir);
        }


        public ActionResult BlogGuncelle(Blog b)
        {
            var bGetir = c.GetBlogs.Find(b.ID);

            bGetir.Baslik = b.Baslik;
            bGetir.Tarih = b.Tarih;
            bGetir.Aciklama = b.Aciklama;
            bGetir.BlogImage = b.BlogImage;
            c.SaveChanges();
            return RedirectToAction("Index");
        }





        //Yorunlar Alanı
        [Authorize]
        public ActionResult Yorumlar()
        {
            var yorumlar = c.Yorumlars.Where(x=>x.YorumOnay==1).ToList();
            var deger= c.Yorumlars.Where(x => x.YorumOnay ==0).Count();
            ViewBag.donenSayi = deger;
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var yorumBul = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(yorumBul);
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }

        public ActionResult YorumGetir(int id)
        {
            var yorumBul = c.Yorumlars.Find(id);         
            return View("YorumGetir",yorumBul);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yGetir = c.Yorumlars.Find(y.ID);

            yGetir.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("Yorumlar");
        }

        public ActionResult OnayBekleyenYorumlar()
        {
            var yorumlar = c.Yorumlars.Where(x => x.YorumOnay == 0).ToList();            
            return View(yorumlar);
        }

        public ActionResult YorumOnayla(Yorumlar y)
        {
            var yGetir = c.Yorumlars.Find(y.ID);
            yGetir.YorumOnay=1;

            c.SaveChanges();
            return RedirectToAction("OnayBekleyenYorumlar");
        }


        //iletişim

        [Authorize]
        public ActionResult Iletisim()
        {

            var bilgiler = c.İletisims.ToList();
            return View(bilgiler);

        }
        public ActionResult MesajSil(int id)
        {
            var bul = c.İletisims.Find(id);

            c.İletisims.Remove(bul);
            c.SaveChanges();
            return RedirectToAction("Iletisim");
        }
        public ActionResult MesajGetir(int id)
        {
            var gelenMesajID = c.İletisims.Find(id);
            return View("MesajGetir",gelenMesajID);
        }







        //Hakkımızda
        [Authorize]

        public ActionResult Hakkimizda()
        {
            int id = 1;
            var deger = c.Hakkimizdas.Find(id);

            return View("Hakkimizda", deger);

        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var deger = c.Hakkimizdas.Find(h.ID);
            deger.fotoUrl = h.fotoUrl;
            deger.Aciklama = h.Aciklama;
            c.SaveChanges();
            return View("Hakkimizda");

        }

    }
}