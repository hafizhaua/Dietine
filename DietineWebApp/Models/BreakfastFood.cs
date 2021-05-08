using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class BreakfastFood
    {
        [Key]
        public int BreakfastFoodID { get; set; }
        [Required]

        [DisplayName("Name")]
        public string BFName { get; set; }

        [DisplayName("Calories (/100 gram)")]
        public double BFCaloriePerOunce { get; set; }
        [DisplayName("Mass (gram)")]
        public double BFGram { get; set; }
        [DisplayName("Total (calories)")]
        public double BFTotalCalorie { get => BFCaloriePerOunce * BFGram / 100; set { } }
        public int BFDbFoodID { get; set; }
        public int BFUserID { get; set; }
        [DisplayName("Date")]
        public DateTime BFDate { get; set; }
    }
}
