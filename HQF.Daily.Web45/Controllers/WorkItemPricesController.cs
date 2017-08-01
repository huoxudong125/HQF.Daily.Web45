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
    public class WorkItemPricesController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkItemPrices
        public ActionResult Index()
        {
            var workItemPrices = db.WorkItemPrices.Include(w => w.WorkItem).Include(w => w.WorkTeam).Include(w => w.WorkTypeUnit);
            return View(workItemPrices.ToList());
        }

        // GET: WorkItemPrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemPrice workItemPrice = db.WorkItemPrices.Find(id);
            if (workItemPrice == null)
            {
                return HttpNotFound();
            }
            return View(workItemPrice);
        }

        // GET: WorkItemPrices/Create
        public ActionResult Create()
        {
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name");
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "ContractName");
            ViewBag.WorkTypeUnitId = new SelectList(db.WorkTypeUnits, "Id", "Id");
            return View();
        }

        // POST: WorkItemPrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkItemId,WorkTypeUnitId,WorkTeamId,Price,Remark,CreateTime,UpdateTime")] WorkItemPrice workItemPrice)
        {
            if (ModelState.IsValid)
            {
                db.WorkItemPrices.Add(workItemPrice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", workItemPrice.WorkItemId);
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "ContractName", workItemPrice.WorkTeamId);
            ViewBag.WorkTypeUnitId = new SelectList(db.WorkTypeUnits, "Id", "Id", workItemPrice.WorkTypeUnitId);
            return View(workItemPrice);
        }

        // GET: WorkItemPrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemPrice workItemPrice = db.WorkItemPrices.Find(id);
            if (workItemPrice == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", workItemPrice.WorkItemId);
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "ContractName", workItemPrice.WorkTeamId);
            ViewBag.WorkTypeUnitId = new SelectList(db.WorkTypeUnits, "Id", "Id", workItemPrice.WorkTypeUnitId);
            return View(workItemPrice);
        }

        // POST: WorkItemPrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkItemId,WorkTypeUnitId,WorkTeamId,Price,Remark,CreateTime,UpdateTime")] WorkItemPrice workItemPrice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workItemPrice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", workItemPrice.WorkItemId);
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "ContractName", workItemPrice.WorkTeamId);
            ViewBag.WorkTypeUnitId = new SelectList(db.WorkTypeUnits, "Id", "Id", workItemPrice.WorkTypeUnitId);
            return View(workItemPrice);
        }

        // GET: WorkItemPrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkItemPrice workItemPrice = db.WorkItemPrices.Find(id);
            if (workItemPrice == null)
            {
                return HttpNotFound();
            }
            return View(workItemPrice);
        }

        // POST: WorkItemPrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkItemPrice workItemPrice = db.WorkItemPrices.Find(id);
            db.WorkItemPrices.Remove(workItemPrice);
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
