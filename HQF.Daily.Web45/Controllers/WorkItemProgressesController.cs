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
    public class WorkItemProgressesController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkItemProgresses
        public ActionResult Index()
        {
            var workItemProgresses = db.WorkItemProgresses.Include(w => w.WorkItemPrice);
            return View(workItemProgresses.ToList());
        }

        // GET: WorkItemProgresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemProgress workItemProgress = db.WorkItemProgresses.Find(id);
            if (workItemProgress == null)
            {
                return HttpNotFound();
            }
            return View(workItemProgress);
        }

        // GET: WorkItemProgresses/Create
        public ActionResult Create()
        {
            ViewBag.WorkItemPriceId = new SelectList(db.WorkItemPrices, "Id", "Remark");
            return View();
        }

        // POST: WorkItemProgresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateTime,CurrentDate,UpdateTime,WorkItemPriceId,WorkQuantity")] WorkItemProgress workItemProgress)
        {
            if (ModelState.IsValid)
            {
                db.WorkItemProgresses.Add(workItemProgress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkItemPriceId = new SelectList(db.WorkItemPrices, "Id", "Remark", workItemProgress.WorkItemPriceId);
            return View(workItemProgress);
        }

        // GET: WorkItemProgresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemProgress workItemProgress = db.WorkItemProgresses.Find(id);
            if (workItemProgress == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkItemPriceId = new SelectList(db.WorkItemPrices, "Id", "Remark", workItemProgress.WorkItemPriceId);
            return View(workItemProgress);
        }

        // POST: WorkItemProgresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateTime,CurrentDate,UpdateTime,WorkItemPriceId,WorkQuantity")] WorkItemProgress workItemProgress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workItemProgress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkItemPriceId = new SelectList(db.WorkItemPrices, "Id", "Remark", workItemProgress.WorkItemPriceId);
            return View(workItemProgress);
        }

        // GET: WorkItemProgresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemProgress workItemProgress = db.WorkItemProgresses.Find(id);
            if (workItemProgress == null)
            {
                return HttpNotFound();
            }
            return View(workItemProgress);
        }

        // POST: WorkItemProgresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkItemProgress workItemProgress = db.WorkItemProgresses.Find(id);
            db.WorkItemProgresses.Remove(workItemProgress);
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
