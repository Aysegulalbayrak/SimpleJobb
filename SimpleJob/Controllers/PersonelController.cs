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
            /*
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("ayeglalbayrak@yahoo.com"));
            email.To.Add(MailboxAddress.Parse(pUye.UyeEmail));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

            // send email
            var smtp = new SmtpClient();
            smtp.Connect("smtp.mail.yahoo.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("[USERNAME]", "[PASSWORD]");
            smtp.Send(email);
            smtp.Disconnect(true);
            /*
            MailAddress alici = new MailAddress(pUye.UyeEmail);
            MailAddress gonderen = new MailAddress("ayeglalbayrak@yahoo.com", "SimpleJob");
           
         
            using (var smtp = new SmtpClient
            {
                Host = "smtp.mail.yahoo.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(gonderen.Address, "Aysgl.123456")
            })
            {
                using (var message = new MailMessage(gonderen, alici))
                {
                    message.Subject = "Simplejob Ekibine Hoşgeldiniz";
                    message.IsBodyHtml = true;
                    message.Body = "Sayın" + pUye.UyeAdi + " " + pUye.UyeSoyadi + "<br/>Seni aramızda görmekten mutluluk duyuyoruz. Uyelik işlemi sırasında sana geçici bir şifre atadık.<br/>Bu şifreyle giriş yapdıktan sonra şifrenizi değişdirmenizi öneririz.<br/> Geçici Şifreniz:" + pUye.UyeSifre;

                    smtp.Send(message);
                }
            }
            /*

            MailMessage mm = new MailMessage(mail.AliciMailAdresi, mail.GondericiMailAdresi);
            mm.Subject = "Simplejob Ekibine Hoşgeldiniz";
            mm.IsBodyHtml = true;
            mm.Body = "Sayın" + pUye.UyeAdi + " " + pUye.UyeSoyadi + "<br/>Seni aramızda görmekten mutluluk duyuyoruz. Uyelik işlemi sırasında sana geçici bir şifre atadık.<br/>Bu şifreyle giriş yapdıktan sonra şifrenizi değişdirmenizi öneririz.<br/> Geçici Şifreniz:" + pUye.UyeSifre;

            SmtpClient clint = new SmtpClient();
            clint.Host = "smtp.gmail.com";
            clint.Port = 587;
            clint.EnableSsl = true;
            NetworkCredential = new NetworkCredential(gonderen.Address, "E.123456")
            */
            db.Uye.Add(pUye);
            db.SaveChanges();
            return RedirectToAction("Index", "Takvim");
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
