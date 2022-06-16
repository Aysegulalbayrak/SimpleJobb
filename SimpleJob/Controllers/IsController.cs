using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleJob.Controllers
{
    public class IsController : Controller
    {
        SimpleJobContext db = new SimpleJobContext();
        // GET: Is
        public ActionResult Index()
        {
            //List<Is> isler = db.Is.ToList();
            var isler = db.Is.Include("Uye").Where(x => x.IsDurumu == true || x.IsDurumu == false);
            return View(isler.ToList());
        }

        public ActionResult Goruntule(int id)
        {
            Is job = db.Is.Include("IsKategori").Include("Uye").SingleOrDefault(x => x.IsId == id);


            return View(job);
        }


       [HttpGet]
       
        public ActionResult Detay(int id)
        {
            using (SimpleJobContext db = new SimpleJobContext()) 
            {
                var job = db.Is.Where(x => x.IsId == id).FirstOrDefault();
             
                return View(job);
            }

        }

        [HttpPost]
        [Route("Detay/{id}")]
        public ActionResult Detay(Is pIs)
        {

            
            if (Session["UyeId"] != null)
            {
                Is job = db.Is.Find(pIs.IsId);
                int uyeId = int.Parse(Session["UyeId"].ToString());
                var model = db.Uye.FirstOrDefault(X => X.UyeId == uyeId);
                job.UslenenUyeId = uyeId;
                job.IsKategoriId = 8;
                job.IsDurumu = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
            

        }

        //Personel yetkisindeki uyenin işlemleri
        public ActionResult Islerim()
        {
           /// Uye uye = db.Uye.Include("Is").SingleOrDefault(x => x.UyeId == id);

            var isler = db.Is.Where(x => x.IsDurumu == true || x.IsDurumu == false);

            if (Session["UyeId"] != null)
            {
                int uyeId = int.Parse(Session["UyeId"].ToString());
                isler = isler.Where(x => x.UslenenUyeId == uyeId);
            }



            return View(isler.ToList());

            
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            Is job = db.Is.Find(id);
            return View(job);
        }
        [HttpPost]
        public ActionResult Duzenle(Is pIs, HttpPostedFileBase DosyaAdresi)
        {
            Is job = db.Is.Find(pIs.IsId);
            
            job.IsAciklama = pIs.IsAciklama;

            
            job.IlerlemeDurumu = pIs.IlerlemeDurumu;
            
            if (DosyaAdresi.ContentLength > 0)
            {
                var dosyaadi = Path.GetFileName(DosyaAdresi.FileName);
                var path = Path.Combine(Server.MapPath("~/Files/"), dosyaadi);
                DosyaAdresi.SaveAs(path);
                pIs.DosyaAdresi = "/Files/" + dosyaadi;
                job.DosyaAdresi = pIs.DosyaAdresi;
            }
            job.IsDurumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ekle()
        {
      
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Is pIs, HttpPostedFileBase DosyaAdresi)
        {
         
            pIs.IlerlemeDurumu = 0;
            pIs.UslenenUyeId = 48;
            pIs.IsKategoriId = 7;
            //pIs.IsDurumu = true;
            if (DosyaAdresi.ContentLength>0)
            {
                var dosyaadi = Path.GetFileName(DosyaAdresi.FileName);
                var path = Path.Combine(Server.MapPath("~/Files/"), dosyaadi);
                DosyaAdresi.SaveAs(path);
                pIs.DosyaAdresi = "/Files/" + dosyaadi;
                
                
            }
            pIs.IsDurumu = true;
            db.Is.Add(pIs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult TeslimEt(int id)
        {
            Is job = db.Is.Find(id);
            job.IlerlemeDurumu = 100;
            job.IsKategoriId = 9;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}