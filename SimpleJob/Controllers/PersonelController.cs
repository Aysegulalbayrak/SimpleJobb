using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SimpleJob.Controllers
{
    public class PersonelController : Controller
    {
        SimpleJobContext db = new SimpleJobContext();
        // GET: Personel
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Uye pUye)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("aysegul.albayrak@std.medipol.edu.tr","SimpleJob");
            mail.To.Add(pUye.UyeEmail);
            pUye.UyeDurumu = true;
            db.Uye.Add(pUye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            Uye uye = db.Uye.Find(id);
            uye.UyeDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
