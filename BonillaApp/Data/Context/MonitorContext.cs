using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonillaApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BonillaApp.Data.Context
{
    public class MonitorContext : DbContext
    {
        public MonitorContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
        {

        }

        public DbSet<DeviceDbo> Devices { get; set; }
        public DbSet<VoltageDbo>  Voltajes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VoltageDbo>()
                .Property(p => p.InsertedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
