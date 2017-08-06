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
    public class WorkTypesController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkTypes
        public ActionResult Index()
        {
            var workTypes = db.WorkTypes.Include(w => w.ParentWorkType);
            return View(workTypes.ToList());
        }

        // GET: WorkTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkType workType = db.WorkTypes.Find(id);
            if (workType == null)
            {
                return HttpNotFound();
            }
            return View(workType);
        }

        // GET: WorkTypes/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.WorkTypes, "Id", "Description");
            return View();
        }

        // POST: WorkTypes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateTime,Description,Name,ParentId,UpdateTime")] WorkType workType)
        {
            if (ModelState.IsValid)
            {
                db.WorkTypes.Add(workType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.WorkTypes, "Id", "Description", workType.ParentId);
            return View(workType);
        }

        // GET: WorkTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkType workType = db.WorkTypes.Find(id);
            if (workType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.WorkTypes, "Id", "Description", workType.ParentId);
            return View(workType);
        }

        // POST: WorkTypes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateTime,Description,Name,ParentId,UpdateTime")] WorkType workType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.WorkTypes, "Id", "Description", workType.ParentId);
            return View(workType);
        }

        // GET: WorkTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkType workType = db.WorkTypes.Find(id);
            if (workType == null)
            {
                return HttpNotFound();
            }
            return View(workType);
        }

        // POST: WorkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkType workType = db.WorkTypes.Find(id);
            db.WorkTypes.Remove(workType);
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
