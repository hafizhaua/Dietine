using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class PlannedFood : Food
    {
        public int PlannedFoodID { get; set; }
        public double Gram { get; set; }
        public double TotalCalorie{ get; set; }
    }
}
