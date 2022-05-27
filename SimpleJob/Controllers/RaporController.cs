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

namespace SimpleJob.Controllers
{
    
    public class RaporController : Controller
    {
        SimpleJobContext db = new SimpleJobContext();
        // GET: Rapor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GrafikOlustur()
        {
            return Json(isler(), JsonRequestBehavior.AllowGet);
        }
        public List<Is1> isler()
        {
            List<Is1> y = new List<Is1>();
            y = db.Is.Select(x => new Is1
            {
                yapilacak = x.(x.IsKategoriId==7).Count(),
                devamEtmekte = Is.Find(x.IsKategoriId == 8),
                tamamlanan = Is.Find(x.IsKategoriId == 9)
            }).ToList();
            return y;
        }
       
    }
}