using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class MealPlan
    {
        public DateTime Tanggal { get; set; }
        public List<PlannedFood> ListBreakfast { get; set; }
        public List<PlannedFood> ListLunch { get; set; }
        public List<PlannedFood> ListDinner { get; set; }
        public List<PlannedFood> ListSnack { get; set; }
        public List<PlannedFood> ListAktivitas { get; set; }
        public double LiterAir { get; set; }
        public double TotalKalori { get; set; }
    }
}
