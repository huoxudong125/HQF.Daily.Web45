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
    public class WorkTeamsController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkTeams
        public ActionResult Index()
        {
            return View(db.WorkTeams.ToList());
        }

        // GET: WorkTeams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTeam workTeam = db.WorkTeams.Find(id);
            if (workTeam == null)
            {
                return HttpNotFound();
            }
            return View(workTeam);
        }

        // GET: WorkTeams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContractName,CreateTime,FullName,MobilePhone,Name,TelPhone,UpdateTime")] WorkTeam workTeam)
        {
            if (ModelState.IsValid)
            {
                db.WorkTeams.Add(workTeam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workTeam);
        }

        // GET: WorkTeams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTeam workTeam = db.WorkTeams.Find(id);
            if (workTeam == null)
            {
                return HttpNotFound();
            }
            return View(workTeam);
        }

        // POST: WorkTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContractName,CreateTime,FullName,MobilePhone,Name,TelPhone,UpdateTime")] WorkTeam workTeam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workTeam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workTeam);
        }

        // GET: WorkTeams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkTeam workTeam = db.WorkTeams.Find(id);
            if (workTeam == null)
            {
                return HttpNotFound();
            }
            return View(workTeam);
        }

        // POST: WorkTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkTeam workTeam = db.WorkTeams.Find(id);
            db.WorkTeams.Remove(workTeam);
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
