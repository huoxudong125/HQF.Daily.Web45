using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HQF.Daily.Web45.DAL;

namespace HQF.Daily.Web45.Controllers
{
    public class WorkTypeUnitsController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkTypeUnits
        public ActionResult Index()
        {
            var workTypeUnits = db.WorkTypeUnits.Include(w => w.WorkType).Include(w => w.WorkUnit);
            return View(workTypeUnits.ToList());
        }

        // GET: WorkTypeUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTypeUnit workTypeUnit = db.WorkTypeUnits.Find(id);
            if (workTypeUnit == null)
            {
                return HttpNotFound();
            }
            return View(workTypeUnit);
        }

        // GET: WorkTypeUnits/Create
        public ActionResult Create()
        {
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id","Name");
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name");
            return View();
        }

        // POST: WorkTypeUnits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateTime,UpdateTime,WorkTypeId,WorkUnitId")] WorkTypeUnit workTypeUnit)
        {
            if (ModelState.IsValid)
            {
                db.WorkTypeUnits.Add(workTypeUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id","Name", workTypeUnit.WorkTypeId);
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name", workTypeUnit.WorkUnitId);
            return View(workTypeUnit);
        }

        // GET: WorkTypeUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTypeUnit workTypeUnit = db.WorkTypeUnits.Find(id);
            if (workTypeUnit == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id","Name", workTypeUnit.WorkTypeId);
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name", workTypeUnit.WorkUnitId);
            return View(workTypeUnit);
        }

        // POST: WorkTypeUnits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateTime,UpdateTime,WorkTypeId,WorkUnitId")] WorkTypeUnit workTypeUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTypeUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id","Name", workTypeUnit.WorkTypeId);
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name", workTypeUnit.WorkUnitId);
            return View(workTypeUnit);
        }

        // GET: WorkTypeUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTypeUnit workTypeUnit = db.WorkTypeUnits.Find(id);
            if (workTypeUnit == null)
            {
                return HttpNotFound();
            }
            return View(workTypeUnit);
        }

        // POST: WorkTypeUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTypeUnit workTypeUnit = db.WorkTypeUnits.Find(id);
            db.WorkTypeUnits.Remove(workTypeUnit);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
