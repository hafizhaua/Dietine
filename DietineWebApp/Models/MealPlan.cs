using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class MealPlan
    {
        public string Tanggal { get; set; }
        public IEnumerable<BreakfastFood> BreakfastList { get; set; }
        public IEnumerable<LunchFood> LunchList { get; set; }
        public IEnumerable<DinnerFood> DinnerList { get; set; }
        public IEnumerable<TakenActivity> ActivityList { get; set; }
        public double LiterAir { get; set; }
        public double TotalKalori { get; set; }
    }
}
