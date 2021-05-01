using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DietineWebApp.Models;

namespace DietineWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DietineWebApp.Models.Food> Food { get; set; }
        public DbSet<DietineWebApp.Models.Activity> Activity { get; set; }
    }
}
