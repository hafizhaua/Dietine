using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class CalorieCalculator
    {
        [Key]
        public int CalculatorID { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage="Value must be greater than 0")]
        [DisplayName("Body Weight (kg)")]
        [Required]
        public double BodyWeight { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [DisplayName("Body Height (cm)")]
        [Required]
        public double BodyHeight { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [Required]
        public int Age { get; set; }

        [Required]
        [DisplayName("Sex")]
        public bool Sex { get; set; }

        [DisplayName("BMR Value (kcal/day)")]
        public double CalculationResult
        {
            get
            {
                if (Sex == true)
                {
                    return 10 * BodyWeight + 6.25 * BodyHeight - 5 * Age + 5;
                }
                else
                {
                    return 10 * BodyWeight + 6.25 * BodyHeight - 5 * Age - 161;
                }
            }

            set { }
        }
    }
}
