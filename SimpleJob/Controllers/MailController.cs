using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using SimpleJob.Models;
using System.Net.Http;

namespace SimpleJob.Controllers
{
    [Authorize]
    public class MailController : Controller
    {
        // GET: Mail
        SimpleJobContext db = new SimpleJobContext();
        public ActionResult Index(string aranacakKelime)
        {
            var mailler = db.Mail.Where(x => x.MailDurumu == true || x.MailDurumu == false);
            if (!string.IsNullOrEmpty(aranacakKelime))
            {
                mailler = mailler.Where(x => x.AliciMailAdresi.Contains(aranacakKelime));
            }
            
            if (Session["UyeId"] !=null)
            {
                int uyeId = int.Parse (Session["UyeId"].ToString());
                mailler = mailler.Where(x => x.UyeId == uyeId);
            }
            


            return View(mailler.ToList());
            
        }

         [HttpGet] 

        public ActionResult Gonder()
        {


                return View();

        }


        [HttpPost]
        public ActionResult Gonder(Mail mail)
        {
            //Mail email = db.Mail.Include("Uye").SingleOrDefault(x => x.GondericiMailAdresi==mail);
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44395/api/Email");
            var consumeWebApi = hc.PostAsJsonAsync<Mail>("Email", mail);
            consumeWebApi.Wait();

            var sendMail = consumeWebApi.Result;

            if (sendMail.IsSuccessStatusCode)
            {
                ViewBag.message = "posta gönderildi" + mail.AliciMailAdresi.ToString();
            }


            
            return View();
        }


        public ActionResult Detay(int id)
        {
            Mail mail = db.Mail.Find(id);

            return View(mail);
        }
    }
}