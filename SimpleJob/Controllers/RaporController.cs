using SimpleJob.Entities.Model;
using SimpleJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using Is1 = SimpleJob.Models.Is1;
//using IsRaporViewModel = SimpleJob.Models.IsRaporViewModel;



namespace SimpleJob.Controllers
{

    public class RaporController : Controller
    {
        
        
        
        // GET: Rapor
        public ActionResult Index()

        {
            IsRaporViewModel models = new IsRaporViewModel();

            using(SimpleJobContext db = new SimpleJobContext()) { 
            List<Is> isler = db.Is.Include("Iskategori").ToList();
            List<Uye> uyeler = db.Uye.Include("Unvan").Where(x => x.UyeDurumu==true).ToList();
            
            models.Tub = new Tuple<List<Is>, List<Uye>>(isler, uyeler);

            }
            return View(models);
        }

        public ActionResult Grafik()
        {
            return Json(IsKategoris(),JsonRequestBehavior.AllowGet);
        }

        public List<Is1> IsKategoris()
        {
            using (SimpleJobContext db = new SimpleJobContext())
            {
                List<Is1> job = new List<Is1>();
                job.Add(new Is1()
                {
                    IsKategoriAdi = "Yapılacak",
                    IsKategoriSayisi = db.Is.Count(x => x.IsKategoriId == 7),

                });
                job.Add(new Is1()
                {
                    IsKategoriAdi = "Devam Etmekte",
                    IsKategoriSayisi = db.Is.Count(x => x.IsKategoriId == 8),

                });
                job.Add(new Is1()
                {
                    IsKategoriAdi = "Tamamlanan",
                    IsKategoriSayisi = db.Is.Count(x => x.IsKategoriId == 9),

                });
                return job;
            }
        }

        
    }
} 