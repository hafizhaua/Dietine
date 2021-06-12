using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class Food
    {
        [Key]
        public int FoodID { get; set; }

        [Required]
        [DisplayName("Food Name")]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Calorie per Ounch (kcal/100gram)")]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
        public double CaloriePerOunce { get; set; }
    }
}
