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

        [DisplayName("Calories (/100 gram)")]
        public double DFCaloriePerOunce { get; set; }
        [DisplayName("Mass (gram)")]
        public double DFGram { get; set; }
        [DisplayName("Total (calories)")]
        public double DFTotalCalorie { get => DFCaloriePerOunce * DFGram / 100; set { } }
        public int DFDbFoodID { get; set; }
        public int DFUserID { get; set; }
        [DisplayName("Date")]
        public DateTime DFDate { get; set; }
    }
}
