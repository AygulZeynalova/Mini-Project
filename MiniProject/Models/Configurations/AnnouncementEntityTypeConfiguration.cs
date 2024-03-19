using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject.Models.Configurations
{
    class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.Property(m => m.Id).HasColumnType("int");
            
            builder.Property(m => m.ModelId).HasColumnType("int");
            builder.Property(m=>m.categories).HasColumnType("int").IsRequired();
            builder.Property(m => m.gears).HasColumnType("int").IsRequired();
            builder.Property(m => m.fuelTypes).HasColumnType("int").IsRequired();
            builder.Property(m => m.transmissions).HasColumnType("int").IsRequired();
            builder.Property(m => m.March).HasColumnType("int").IsRequired();
            builder.Property(m => m.Year).HasColumnType("int").IsRequired();
            builder.Property(m => m.Price).HasColumnType("decimal").IsRequired().HasPrecision(18, 2);



            builder.ConfigureAuiditable();

            builder.HasKey(m => m.Id);
            builder.ToTable("Announcements");
        }
    }
}
