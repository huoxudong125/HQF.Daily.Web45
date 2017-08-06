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
    public class WorkAreasController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkAreas
        public ActionResult Index()
        {
            var workAreas = db.WorkAreas.Include(w => w.Project);
            return View(workAreas.ToList());
        }

        // GET: WorkAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkArea workArea = db.WorkAreas.Find(id);
            if (workArea == null)
            {
                return HttpNotFound();
            }
            return View(workArea);
        }

        // GET: WorkAreas/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Decription");
            return View();
        }

        // POST: WorkAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateTime,Name,Position,ProjectId,Remark,UpdateTime")] WorkArea workArea)
        {
            if (ModelState.IsValid)
            {
                db.WorkAreas.Add(workArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Decription", workArea.ProjectId);
            return View(workArea);
        }

        // GET: WorkAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkArea workArea = db.WorkAreas.Find(id);
            if (workArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Decription", workArea.ProjectId);
            return View(workArea);
        }

        // POST: WorkAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateTime,Name,Position,ProjectId,Remark,UpdateTime")] WorkArea workArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Decription", workArea.ProjectId);
            return View(workArea);
        }

        // GET: WorkAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkArea workArea = db.WorkAreas.Find(id);
            if (workArea == null)
            {
                return HttpNotFound();
            }
            return View(workArea);
        }

        // POST: WorkAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkArea workArea = db.WorkAreas.Find(id);
            db.WorkAreas.Remove(workArea);
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
