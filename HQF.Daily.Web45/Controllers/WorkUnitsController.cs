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
    public class WorkUnitsController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkUnits
        public ActionResult Index()
        {
            return View(db.WorkUnits.ToList());
        }

        // GET: WorkUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkUnit workUnit = db.WorkUnits.Find(id);
            if (workUnit == null)
            {
                return HttpNotFound();
            }
            return View(workUnit);
        }

        // GET: WorkUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkUnits/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateTime,Name,UpdateTime")] WorkUnit workUnit)
        {
            if (ModelState.IsValid)
            {
                db.WorkUnits.Add(workUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workUnit);
        }

        // GET: WorkUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkUnit workUnit = db.WorkUnits.Find(id);
            if (workUnit == null)
            {
                return HttpNotFound();
            }
            return View(workUnit);
        }

        // POST: WorkUnits/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateTime,Name,UpdateTime")] WorkUnit workUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workUnit);
        }

        // GET: WorkUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkUnit workUnit = db.WorkUnits.Find(id);
            if (workUnit == null)
            {
                return HttpNotFound();
            }
            return View(workUnit);
        }

        // POST: WorkUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkUnit workUnit = db.WorkUnits.Find(id);
            db.WorkUnits.Remove(workUnit);
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
