using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DietineWebApp.Models
{
    public class TakenActivity
    {
        [Key]
        public int TakenActivityID { get; set; }
        [DisplayName("Name")]
        public string TAName { get; set; }
        [DisplayName("Burned Calorie (kkal/minute)")]
        public double TACalorieBurnedPerMinute { get; set; }
        [DisplayName("Duration (minute)")]
        public double TAMinute { get; set; }
        [DisplayName("Total Burned Calorie (kkal)")]
        public double TATotalCaloriBurned { get => Math.Round(-(TACalorieBurnedPerMinute * TAMinute), 3); set { } }
        [DisplayName("Date")]
        public string TADate { get; set; }
        public int TADbID { get; set; }
        public string TAUserID { get; set; }

    }
}
