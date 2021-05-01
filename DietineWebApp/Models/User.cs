using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace DietineWebApp.Models
{
    public class User : IdentityUser
    {
        public double TinggiBadan { get; set; }
        public double BeratBadan { get; set; }
        public double Usia { get; set; }
        public bool Kelamin { get; set; }
    }
}
