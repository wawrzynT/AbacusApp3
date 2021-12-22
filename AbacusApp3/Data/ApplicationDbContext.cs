using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AbacusApp3.Models;

namespace AbacusApp3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AbacusApp3.Models.Konto> Konto { get; set; }
        public DbSet<AbacusApp3.Models.Lokalizacja> Lokalizacja { get; set; }
        public DbSet<AbacusApp3.Models.Osoba> Osoba { get; set; }
        public DbSet<AbacusApp3.Models.Ksiegowanie> Ksiegowanie { get; set; }


    }
}
