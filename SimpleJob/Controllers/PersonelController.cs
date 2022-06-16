using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SimpleJob.Entities.Model;
using SimpleJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Mail = SimpleJob.Entities.Model.Mail;

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
            pUye.UyeUnvanId = 5;
            pUye.UyeDurumu = true;
            pUye.UyeIseBaslamaTarihi = DateTime.Now;
            pUye.Fotograf = "/Files/1000_F_223507324_jKl7xbsaEdUjGr42WzQeSazKRighVDU4.jpg";
            pUye.UyeSifre = ParolaOlusturma.Olustur(8);
           
            //Eposta gönderme
            SmtpClient clint = new SmtpClient("smtp-mail.outlook.com");
            clint.Port = 587;
            clint.DeliveryMethod = SmtpDeliveryMethod.Network;
            clint.UseDefaultCredentials = false;
            NetworkCredential cr = new NetworkCredential("ala396397@outlook.com", "Ayse.123456");
            clint.EnableSsl = true;
            clint.Credentials = cr;

            MailMessage mm = new MailMessage("ala396397@outlook.com",pUye.UyeEmail);
            mm.Subject = "Simplejob Ekibine Hoşgeldiniz";
            mm.IsBodyHtml = true;
            
            mm.Body = "<img style='height:80px; widht:80px;' src='C:/Users/asus/source/repos/SimpleJobb/SimpleJob/images/son.png'/></br>" + "Sayın " + pUye.UyeAdi + " " + pUye.UyeSoyadi + "<br/>Seni aramızda görmekten mutluluk duyuyoruz. Üyelik işlemi sırasında sana geçici bir şifre atadık.<br/>Bu şifreyle giriş yapdıktan sonra şifrenizi değişdirmenizi öneririz.<br/> <b>Geçici Şifreniz: </b>" + pUye.UyeSifre;
            clint.Send(mm);
            db.Uye.Add(pUye);
            db.SaveChanges();
            return RedirectToAction("Index", "Rapor");
        }
        

        public ActionResult Sil(int id)
        {
            Uye uye = db.Uye.Find(id);
            uye.UyeDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index","Rapor");
        }
    }
}
