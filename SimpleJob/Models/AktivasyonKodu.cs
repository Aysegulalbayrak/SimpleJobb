using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SimpleJob.Models
{
    public static class AktivasyonKodu
    {
        public static string AktivasyonKoduGonder(string uyeMail)
        {
            string mail = "gönderenMail";
            string sifre = "gönderenŞifre";

            Random rnd = new Random();
            string karakter = "ABCDEFGHIJKLMNOPRSTUVYZWX0123456789";
            string kod = "";
            for (int i = 0; i < 6; i++)
            {
                kod += karakter[rnd.Next(karakter.Length)];
            }
            try
            {
                string yol = "http://localhost:25796/UyeOl/Index?Kod=" + kod;
                MailMessage mesaj = new MailMessage(mail, uyeMail, "Onay Kodu", "Üyeliğinizin onaylanması için bu adresten aktivasyon işleminizi yapabilirsiniz\n\n" + yol);
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(mail, sifre);
                smtp.EnableSsl = true;

                smtp.Send(mesaj);
                return kod;
            }
            catch (Exception ex)
            {
                new Exception("Onay Kodu Gönderiminde Hata" + ex.Message);
            }
            return kod;
        }

    }
}