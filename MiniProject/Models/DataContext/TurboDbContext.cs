using Microsoft.EntityFrameworkCore;
using MiniProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Models.DataContext
{
    public class TurboDbContext : DbContext
    {
        public TurboDbContext()
            :base()
        {
                


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Database=TurboAzDb;User Id=sa;Password=!Dquery20@4;Encrypt=false;",
               opt =>
               {
                   opt.MigrationsHistoryTable("MigrationHistory");
               }
                   );
        }

         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = typeof(TurboDbContext).Assembly;
        }


        public DbSet<Announcement> announcements { get; set; }
        public DbSet <Brand> brands { get; set; }
        public DbSet <Model> models { get; set; }

    }
    
}
