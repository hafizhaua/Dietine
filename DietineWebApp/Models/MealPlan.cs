using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class MealPlan
    {
        public DateTime Tanggal { get; set; }
        public double LiterAir { get; set; }
        public double TotalKalori { get; set; }
    }
}
