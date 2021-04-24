using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dietine.Models
{
    public class MealPlanModel
    {
        public DateTime Tanggal { get; set; }
        public List<PlannedMakananModel> ListBreakfast { get; set; }
        public List<PlannedMakananModel> ListLunch { get; set; }
        public List<PlannedMakananModel> ListDinner { get; set; }
        public List<PlannedMakananModel> ListSnack { get; set; }
        public List<PlannedMakananModel> ListAktivitas { get; set; }
        public double LiterAir { get; set; }
        public double TotalKalori { get; set; }

        public void setTanggal() { }
        public void setBreakfast() { }
        public void setLunch() { }
        public void setDinner() { }
        public void setSnack() { }
        public void setAktivitas() { }
        public void setAir() { }
    }
}
