using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T2_ESCATE_ALEXANDER.Models;

namespace T2_ESCATE_ALEXANDER.Datos
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Distribuidor> Distribuidor { get; set; }

        public DbSet<Libro> Libro { get; set; }
    }
}
