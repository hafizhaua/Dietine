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

        [DisplayName("Calories (/100 gram)")]
        public double LFCaloriePerOunce { get; set; }
        [DisplayName("Mass (gram)")]
        public double LFGram { get; set; }
        [DisplayName("Total (calories)")]
        public double LFTotalCalorie { get => LFCaloriePerOunce * LFGram / 100; set { } }
        public int LFDbFoodID { get; set; }
        public int LFUserID { get; set; }
        [DisplayName("Date")]
        public DateTime LFDate { get; set; }
    }
}
