using SimpleJob.Entities.Model;
using SimpleJob.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Net;
using System.Net.Mail;
using Mail = SimpleJob.Entities.Model.Mail;

namespace SimpleJob.Controllers
{
    [AllowAnonymous]
    public class GirisController : Controller
    {
        SimpleJobContext db = new SimpleJobContext();
        // GET: Giris
        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(Uye pUye)
        {
            pUye.UyeKAdi = pUye.UyeEmail;

           
            var uye = db.Uye.FirstOrDefault(x => (x.UyeEmail == pUye.UyeEmail || x.UyeKAdi == pUye.UyeKAdi) && x.UyeSifre == pUye.UyeSifre);
            

            if (uye != null)
                {
                    FormsAuthentication.SetAuthCookie(uye.UyeKAdi, false);
                    
                    Session["UyeId"] = uye.UyeId;
                    Session["UyeEmail"] = uye.UyeEmail;
                    Session["Uye"] = uye.UyeAdi+" "+uye.UyeSoyadi;
                    Session["UyeFoto"] = uye.Fotograf;
                    Session["UyeYetkiId"] = uye.UyeUnvanId;
                    
                    return RedirectToAction("Index", "Is");

                }
                else
                {
                ViewBag.LoginError = "Hatalı kullanıcı adı  veya şifre girdiniz.";
                return View();
                }
            

            
        }

       

        public ActionResult CikisYap()
        {
            Session.Clear();
            
            FormsAuthentication.SignOut();
            return RedirectToAction("Giris");
        }

    }
}