using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcRiku.Models;

    public class MvcSuperHeroesContext : DbContext
    {
        public MvcSuperHeroesContext (DbContextOptions<MvcSuperHeroesContext> options)
            : base(options)
        {
        }

        public DbSet<MvcRiku.Models.SuperHeroe> SuperHeroe { get; set; } = default!;
    }
