using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HQF.Daily.Web45.Models
{
    public class WorkAreaProgress
    {
        public WorkAreaProgress()
        {
            DailyWorkItemProgresses = new List<DaysWorkItemProgress>();
        }
        
        public string WorkAreaName { get; set; }

        
        List<DaysWorkItemProgress> DailyWorkItemProgresses { get; set; }

      

    }

    public class DaysWorkItemProgress
    {
        public DaysWorkItemProgress()
        {
            DailyProgesses = new List<DailyWorkProgress>();
        }

        public string WorkItemName { get; set; }

        public List<DailyWorkProgress> DailyProgesses { get; set; }
    }


    public class DailyWorkProgress
    {

        public DateTime Day { get; set; }

        public float WorkQuantity { get; set; }
    }


    public class DailyWorkAreaProgress
    {
        public DateTime Day { get; set; }

        public string WorkAreaName { get; set; }

        public string WorkItemName { get; set; }

        public double WorkQuantity { get; set; }
    }


}