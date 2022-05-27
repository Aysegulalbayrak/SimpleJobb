using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleJob.Models;
using System.Net.Mail;


namespace SimpleJob.Controllers
{
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        [HttpPost]
        [Route("send-email")]
        public IHttpActionResult mailGonder(Mail mail)
        {
            string AliciMailAdresi = mail.AliciMailAdresi;
            string GondericiMailAdresi = mail.GondericiMailAdresi;
            string MailBaslik = mail.MailBaslik;
            string MailAciklama = mail.MailAciklama;
            

            MailMessage ePosta = new MailMessage();
            ePosta.From = new MailAddress(GondericiMailAdresi);
            ePosta.To.Add(AliciMailAdresi);
            //ePosta.Attachments.Add(new Attachment(@"C:\deneme-upload.jpg"));
            ePosta.Subject = mail.MailBaslik;
            ePosta.Body = mail.MailAciklama;
            ePosta.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential(GondericiMailAdresi, "A.1234567");
            smtp.Send(ePosta);
            object userState = ePosta;
            return Ok();    
        }
    }
}
