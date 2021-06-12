using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class LunchFood
    {
        [Key]
        public int LunchFoodID { get; set; }
        [Required]

        [DisplayName("Name")]
        public string LFName { get; set; }

        [DisplayName("Calorie Ratio (kcal/100 gram)")]
        public double LFCaloriePerOunce { get; set; }
        [DisplayName("Quantity (gram)")]
        public double LFGram { get; set; }
        [DisplayName("Total Calories (kcal)")]
        public double LFTotalCalorie { get => Math.Round(LFCaloriePerOunce * LFGram / 100, 3); set { } }
        public int LFDbFoodID { get; set; }
        public string LFUserID { get; set; }
        [DisplayName("Date")]
        public string LFDate { get; set; }
    }
}
