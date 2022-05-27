using SimpleJob.Entities.Model;
using SimpleJob.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleJob.Controllers
{
    public class ProfilController : Controller
    {
        // GET: Profil
        SimpleJobContext db = new SimpleJobContext();
     

        public ActionResult Index()
        {
            
            var kullanici = db.Uye.Where(x => x.UyeDurumu == true );
            if (Session["UyeId"] != null)
            {
                
                int uyeId = int.Parse(Session["UyeId"].ToString());
                kullanici = kullanici.Where(x => x.UyeId == uyeId);
                Uye u = db.Uye.Include("Unvan").SingleOrDefault(x => x.UyeId == uyeId);
                Uye uye = db.Uye.Find(uyeId);
                return View(uye);
            }
            return View();
            

            
        }
        [HttpGet]
        public ActionResult Duzenle()
        {
            var kullanici = db.Uye.Where(x => x.UyeDurumu == true);
            if (Session["UyeId"] != null)
            {

                int uyeId = int.Parse(Session["UyeId"].ToString());
                kullanici = kullanici.Where(x => x.UyeId == uyeId);
                
                Uye uye = db.Uye.Find(uyeId);
                return View(uye);
            }
            return View();

        }
        [HttpPost]
        public ActionResult Duzenle(Uye pUye, HttpPostedFileBase Fotograf)
        {
            var kullanicilar = db.Uye.Where(x => x.UyeDurumu == true);
            if (Session["UyeId"] != null)
            {

                int uyeId = int.Parse(Session["UyeId"].ToString());
               

                Uye uye = db.Uye.Find(uyeId);
                uye.UyeAdi = pUye.UyeAdi;
                uye.UyeSoyadi = pUye.UyeSoyadi;
                uye.UyeEmail = pUye.UyeEmail;
                uye.UyeKAdi = pUye.UyeKAdi;
                uye.UyeSifre = pUye.UyeSifre;
                uye.github = pUye.github;
                uye.linkedln = pUye.linkedln;
                if (Fotograf.ContentLength > 0)
                {
                    var dosyaadi = Path.GetFileName(Fotograf.FileName);
                    var path = Path.Combine(Server.MapPath("~/Files/"), dosyaadi);
                    Fotograf.SaveAs(path);
                    pUye.Fotograf = "/Files/" + dosyaadi;
                    uye.Fotograf = pUye.Fotograf;

                }

                //db.Uye.Attach(pUye);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }
   
    }
}