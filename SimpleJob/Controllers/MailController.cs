using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleJob.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        SimpleJobContext db = new SimpleJobContext();
   
        [HttpGet]
        public ActionResult Send()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Send(Mail pMail)
        {


            pMail.GondericiId = int.Parse(Session["UyeId"].ToString());
            pMail.MailTarih = DateTime.Now;
            pMail.MailDurumu = true;
            db.Mail.Add(pMail);
            db.SaveChanges();
            return RedirectToAction("Giden");


        }

        public ActionResult Gelen()
        {
            var gelenler = db.Mail.Include("Uye").Where(x => x.MailDurumu == true ) ;

            if (Session["UyeId"] != null)
            {
                int uyeId = int.Parse(Session["UyeId"].ToString());
                gelenler = gelenler.Where(x => x.UyeId == uyeId);
            }
            return View(gelenler.ToList());

        }

        public ActionResult Giden()
        {

            var gidenler = db.Mail.Include("Uye").Where(x => x.MailDurumu == true );
            if (Session["UyeId"] != null)
            {
                int uyeId = int.Parse(Session["UyeId"].ToString());
                gidenler = gidenler.Where(x => x.GondericiId == uyeId);
            }
            return View(gidenler.ToList());
        }

        public ActionResult Detay(int id)
        {
            var mail = db.Mail.Where(x => x.MailId == id).FirstOrDefault();

            return View(mail);
        }

        [HttpGet]
        public ActionResult Garbage()
        {
            var silinenler = db.Mail.Include("Uye").Where(x => x.MailDurumu == true);
            return View(silinenler);
        }

        [HttpPost]
        public ActionResult Garbage(int id)
        {
            Mail mail = db.Mail.Find(id);
            mail.MailDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Garbage");
        }
      


    }
}