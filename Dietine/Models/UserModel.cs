using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dietine.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double TinggiBadan { get; set; }
        public double BeratBadan { get; set; }
        public double Usia { get; set; }
        public bool Kelamin { get; set; }
        public List<MealPlanModel> ListMealPlan { get; set; }

        // constructor
        public UserModel(double tinggiBadan, double beratBadan, double usia, bool kelamin)
        {
            TinggiBadan = tinggiBadan;
            BeratBadan = beratBadan;
            Usia = usia;
            Kelamin = kelamin;
        }

        public void SetBiodata(double tinggiBadan, double beratBadan, double usia, bool kelamin)
        {
            TinggiBadan = tinggiBadan;
            BeratBadan = beratBadan;
            Usia = usia;
            Kelamin = kelamin;
        }
    }
}
