using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Activity Name")]
        public string ActivityName { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Value must be greater than 0")]
        [DisplayName("Calorie burned per minute (kkal/min)")]
        public double CalorieBurnedPerMinute{ get; set; }
    }
}
