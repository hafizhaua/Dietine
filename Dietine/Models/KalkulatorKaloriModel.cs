using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dietine.Models
{
    public class KalkulatorKaloriModel
    {
        public string Nama { get; set; }
        public double BeratBadan { get; set; }
        public double TinggiBadan { get; set; }
        public int Usia { get; set; }
        public bool Kelamin { get; set; }
        public double HasilPerhitungan { get; set; }

        public double HitungBMR()
        {
            // Menghitung BMR (Basal Metabolic Rate) dengan satuan kkal/hari

            double BMR;

            // Men
            if (this.Kelamin)
            {
                BMR = 10 * BeratBadan + 6.25 * TinggiBadan - 5 * Usia + 5;
            }
            else // Women
            {
                BMR = 10 * BeratBadan + 6.25 * TinggiBadan - 5 * Usia - 161;
            }
            return BMR;
        }

        public double Hitung(UserModel user)
        {
            // Menghitung BMR (Basal Metabolic Rate) dengan satuan kkal/hari
            double BMR;

            // Men
            if (user.Kelamin)
            {
                BMR = 10 * user.BeratBadan + 6.25 * user.TinggiBadan - 5 * user.Usia + 5;
            }
            else // Women
            {
                BMR = 10 * user.BeratBadan + 6.25 * user.TinggiBadan - 5 * user.Usia - 161;
            }
            return BMR;
        }
    }
}
