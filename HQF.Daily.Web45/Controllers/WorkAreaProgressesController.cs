using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using HQF.Daily.Web45.DAL;
using HQF.Daily.Web45.Models;

namespace HQF.Daily.Web45.Controllers
{
    public class WorkAreaProgressesController : Controller
    {
        private DailyDbContext db = new DailyDbContext();

        // GET: WorkAreaProgresses
        public ActionResult Index()
        {
            var WorkAreaProgess = db.WorkItemProgresses
                .Include(t => t.WorkTeam)
                .Include(t => t.WorkItem)
                .Include(t => t.WorkItem.WorkArea)
                .Select(t => new DailyWorkAreaProgress()
                {
                    Day = t.CurrentDate,
                    WorkAreaName = t.WorkItem.WorkArea.Name,
                    WorkItemName = t.WorkItem.Name,
                    WorkQuantity = t.WorkQuantity
                }).ToList(); 



            return View(WorkAreaProgess);
        }
    }
}