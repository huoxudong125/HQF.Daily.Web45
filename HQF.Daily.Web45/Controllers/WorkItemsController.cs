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
    public class WorkItemsController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkItems
        public ActionResult Index()
        {
            var workItems = db.WorkItems.Include(w => w.ParentWorkItem).Include(w => w.WorkArea).Include(w => w.WorkType);
            return View(workItems.ToList());
        }

        // GET: WorkItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // GET: WorkItems/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.WorkItems, "Id", "Name");
            ViewBag.WorkAreaId = new SelectList(db.WorkAreas, "Id", "Name");
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id", "Name");
            return View();
        }

        // POST: WorkItems/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ParentId,Remark,WorkAreaId,WorkTypeId")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                db.WorkItems.Add(workItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParentId = new SelectList(db.WorkItems, "Id", "Name", workItem.ParentId);
            ViewBag.WorkAreaId = new SelectList(db.WorkAreas, "Id", "Name", workItem.WorkAreaId);
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id", "Name", workItem.WorkTypeId);
            return View(workItem);
        }

        // GET: WorkItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.WorkItems, "Id", "Name", workItem.ParentId);
            ViewBag.WorkAreaId = new SelectList(db.WorkAreas, "Id", "Name", workItem.WorkAreaId);
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id", "Name", workItem.WorkTypeId);
            return View(workItem);
        }

        // POST: WorkItems/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateTime,Name,ParentId,Remark,UpdateTime,WorkAreaId,WorkTypeId")] WorkItem workItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParentId = new SelectList(db.WorkItems, "Id", "Name", workItem.ParentId);
            ViewBag.WorkAreaId = new SelectList(db.WorkAreas, "Id", "Name", workItem.WorkAreaId);
            ViewBag.WorkTypeId = new SelectList(db.WorkTypes, "Id", "Name", workItem.WorkTypeId);
            return View(workItem);
        }

        // GET: WorkItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItem workItem = db.WorkItems.Find(id);
            if (workItem == null)
            {
                return HttpNotFound();
            }
            return View(workItem);
        }

        // POST: WorkItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkItem workItem = db.WorkItems.Find(id);
            db.WorkItems.Remove(workItem);
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
