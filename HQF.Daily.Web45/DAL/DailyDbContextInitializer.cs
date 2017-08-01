using System;
using System.Data.Entity;

namespace HQF.Daily.Web45.DAL
{
    public class DailyDbContextInitializer : DropCreateDatabaseAlways<DailyDbContext>
    {
        protected override void Seed(DailyDbContext context)
        {
            base.Seed(context);

            var project = new Project
            {
                Name = "汾平高速"
            };

            context.Projects.Add(project);


            var workArea = new WorkArea
            {
                Name = "工区一",
                Project = project
            };
            context.WorkAreas.Add(workArea);

            context.SaveChanges();

            var workTypeBridge = new WorkType {Name = "桥梁"};
            var workTypeBridgeFirstStep = new WorkType
            {
                Name = "开挖",
                ParentWorkType = workTypeBridge
            };

            context.WorkTypes.Add(workTypeBridge);
            context.WorkTypes.Add(workTypeBridgeFirstStep);

            context.SaveChanges();


            var workUnit = new WorkUnit {Name = "立方米"};
            context.WorkUnits.Add(workUnit);


            var bridgeWorkUnit =
                new WorkTypeUnit
                {
                    WorkTypeId = workTypeBridgeFirstStep.Id,
                    WorkUnitId = workUnit.Id
                };
            context.WorkTypeUnits.Add(bridgeWorkUnit);

            context.SaveChanges();

            var workTeam = new WorkTeam {Name = "杜村建工一局"};

            context.WorkTeams.Add(workTeam);

            var workitem = new WorkItem
            {
                Name = "平遥杜村一桥",
                WorkType = workTypeBridge,
                WorkArea = workArea
            };
            var subWorkitem = new WorkItem
            {
                Name = "平遥杜村一桥 开挖",
                WorkType = workTypeBridgeFirstStep,
                WorkArea = workArea,
                ParentWorkItem = workitem
            };

            context.WorkItems.Add(workitem);
            context.WorkItems.Add(subWorkitem);

            context.SaveChanges();


            var workItemPrice = new WorkItemPrice
            {
                WorkTeam = workTeam,
                WorkItem = subWorkitem,
                WorkTypeUnit = bridgeWorkUnit,
                Price = 50
            };

            context.WorkItemPrices.Add(workItemPrice);

            context.SaveChanges();

            var workItemProgess = new WorkItemProgress
            {
                CurrentDate = DateTime.Parse("2017-07-01"),
                WorkItemPrice = workItemPrice,
                WorkQuantity = 10
            };

            context.WorkItemProgresses.Add(workItemProgess);

            context.SaveChanges();
        }
    }
}