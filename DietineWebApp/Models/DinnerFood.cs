using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class DinnerFood
    {
        [Key]
        public int DinnerFoodID { get; set; }
        [Required]

        [DisplayName("Name")]
        public string DFName { get; set; }

        [DisplayName("Calorie Ratio (kkal/100 gram)")]
        public double DFCaloriePerOunce { get; set; }
        [DisplayName("Quantity (gram)")]
        public double DFGram { get; set; }
        [DisplayName("Total Calories (kkal)")]
        public double DFTotalCalorie { get => Math.Round(DFCaloriePerOunce * DFGram / 100, 3); set { } }
        public int DFDbFoodID { get; set; }
        public int DFUserID { get; set; }
        [DisplayName("Date")]
        public string DFDate { get; set; }
    }
}
