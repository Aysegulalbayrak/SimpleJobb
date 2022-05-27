using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleJob.Models
{
    public static class giris
    {
        public static Uye Uye;

        //iş kategori
        public static List<IsKategori> IsKategoris
        {
            get
            {
                if (IsKategoris == null)
                {
                    KategorileriListele();
                }
                return IsKategoris;
            }
            set { IsKategoris = value; }
        }

        private static void KategorileriListele()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                IsKategoris = db.IsKategori.AsNoTracking().ToList();
            }
        }

        //ıs
        private static List<Entities.Model.Is> ises;

        public static List<Entities.Model.Is> Ises
        {
            get
            {
                if (ises == null)
                {
                    IsleriListele();
                }
                return ises;
            }
            set { ises = value; }
        }

        private static void IsleriListele()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                ises = db.Is.AsNoTracking().ToList();
            }

        }

        //Uye
        private static List<Uye> uyes;

        public static List<Uye> Uyes
        {
            get
            {
                if (uyes == null)
                {
                    UyeleriListele();
                }
                return uyes;
            }
            set { uyes = value; }
        }

        private static void UyeleriListele()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                uyes = db.Uye.AsNoTracking().ToList();
            }
        }


        //Rapor
        private static List<Entities.Model.Rapor> rapors;
        public static List<Entities.Model.Rapor> Rapors
        {
            get
            {
                if (rapors == null)
                {
                    RaporListele();
                }
                return rapors;
            }
            set { rapors = value; }
        }
        private static void RaporListele()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                rapors = db.Rapor.AsNoTracking().ToList();
            }
        }

        //Takvim
        private static List<Takvim> takvims;
        public static List<Takvim> Takvims
        {
            get
            {
                if (takvims == null)
                {
                    TakvimListele();
                }
                return takvims;
            }
            set { takvims = value; }
        }
        private static void TakvimListele()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                takvims = db.Takvim.AsNoTracking().ToList();
            }
        }

        //Mail
        private static List<Mail> mails;
        public static List<Mail> Mails
        {
            get
            {
                if (mails == null)
                {
                    MailListele();
                }
                return mails;
            }
            set { mails = value; }
        }
        private static void MailListele()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                mails = db.Mail.AsNoTracking().ToList();
            }
        }

        public static void Clear()
        {
            // Chahce Clear
            Ises = null;
            IsKategoris = null;
            Uyes = null;
            Mails = null;
            Rapors = null;
            Uye = null;
            

        }


    }
}