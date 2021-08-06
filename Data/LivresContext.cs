using Microsoft.EntityFrameworkCore;
using ProjetBDLivres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetBDLivres.Data
{
    public class LivresContext:DbContext
    {
        public LivresContext(DbContextOptions<LivresContext> options) : base(options)
        {}
        public DbSet<Livres> Livres { get; set; }
        public DbSet<LivresDesires> LivresDesires { get; set; }
        public DbSet<Utilisateurs> Utilisateurs { get; set; }

    }
}
