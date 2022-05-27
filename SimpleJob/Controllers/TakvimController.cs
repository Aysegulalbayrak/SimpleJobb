using SimpleJob.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleJob.Controllers
{
    public class TakvimController : Controller
    {
        // GET: Takvim
        
        SimpleJobContext db = new SimpleJobContext();
        
        public ActionResult Index()
        {
            List<Takvim> events = db.Takvim.AsNoTracking().Where(x => x.takvimDurumu == true).ToList();
            return View(events);
        }

        public JsonResult EventleriGetir()
        {
            using(SimpleJobContext db= new SimpleJobContext()) { 
             var events = db.Takvim.ToList();
                return new JsonResult { Data =events,JsonRequestBehavior=JsonRequestBehavior.AllowGet };
            }

        }

        [HttpPost]
        public JsonResult EventEkle(Takvim ptakvim)
        {
            var status = false;
            using (SimpleJobContext db = new SimpleJobContext())
            {
                if (ptakvim.TakvimId>0)
                {
                    //Eventi güncelle
                    var v = db.Takvim.Where(a => a.TakvimId == ptakvim.TakvimId).FirstOrDefault();
                    if (v!=null)
                    {
                        v.title = ptakvim.title;
                        v.start = ptakvim.start;
                        v.end = ptakvim.end;
                        v.color = ptakvim.color;
                        v.textColor = ptakvim.textColor;
                    }
                }
                else
                {
                    db.Takvim.Add(ptakvim);
                }
                db.SaveChanges();
                status = true;
            }
                return new JsonResult { Data = new { status = status } };


        }


        [HttpPost]
        public JsonResult EventSil(int takvimId)
        {

            var status = false;
            using (SimpleJobContext db = new SimpleJobContext())
            {
                
                var v = db.Takvim.Where(x => x.TakvimId == takvimId).FirstOrDefault();
                if (v != null)
                {
                    db.Takvim.Remove(v);
                    db.SaveChanges();

                }
            }
            return new JsonResult { Data= new { status = status } };
        }

    }
}