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
            var workItemProgresses = db.WorkItemProgresses
                .Include(w => w.ConcreteMixingStation)
                .Include(w => w.User)
                .Include(w => w.WorkItem)
                .Include(w => w.WorkTeam)
                .Include(w => w.WorkUnit);
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
            ViewBag.MixingStationId = new SelectList(db.ConcreteMixingStations, "Id", "Name");
            ViewBag.OperatorId = new SelectList(db.Users, "Id", "Name");
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name");
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "Name");
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name");
            
            return View();
        }

        // POST: WorkItemProgresses/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CurrentDate,WorkItemId,WorkTeamId,WorkPrice,WorkUnitId,WorkQuantity,MixingStationId,OperatorId,Remark,CreateTime,UpdateTime")] WorkItemProgress workItemProgress)
        {
            if (ModelState.IsValid)
            {
                db.WorkItemProgresses.Add(workItemProgress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MixingStationId = new SelectList(db.ConcreteMixingStations, "Id", "Name", workItemProgress.MixingStationId);
            ViewBag.OperatorId = new SelectList(db.Users, "Id", "Name", workItemProgress.OperatorId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", workItemProgress.WorkItemId);
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "Name", workItemProgress.WorkTeamId);
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name", workItemProgress.WorkUnitId);

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
            ViewBag.MixingStationId = new SelectList(db.ConcreteMixingStations, "Id", "Name", workItemProgress.MixingStationId);
            ViewBag.OperatorId = new SelectList(db.Users, "Id", "Name", workItemProgress.OperatorId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", workItemProgress.WorkItemId);
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "Name", workItemProgress.WorkTeamId);
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name", workItemProgress.WorkUnitId);
            return View(workItemProgress);
        }

        // POST: WorkItemProgresses/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CurrentDate,WorkItemId,WorkTeamId,WorkPrice,WorkUnitId,WorkQuantity,MixingStationId,OperatorId,Remark,CreateTime,UpdateTime")] WorkItemProgress workItemProgress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workItemProgress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MixingStationId = new SelectList(db.ConcreteMixingStations, "Id", "Name", workItemProgress.MixingStationId);
            ViewBag.OperatorId = new SelectList(db.Users, "Id", "Name", workItemProgress.OperatorId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", workItemProgress.WorkItemId);
            ViewBag.WorkTeamId = new SelectList(db.WorkTeams, "Id", "Name", workItemProgress.WorkTeamId);
            ViewBag.WorkUnitId = new SelectList(db.WorkUnits, "Id", "Name", workItemProgress.WorkUnitId);
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
