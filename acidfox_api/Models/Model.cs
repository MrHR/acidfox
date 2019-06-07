using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace acidfox_api.Models
{
    public class AcidFoxContext : DbContext
    {
        public AcidFoxContext(DbContextOptions<AcidFoxContext> options)
            : base(options)
        { }

        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("User ID=rubenhannon;Password=Ballonbruisbal;Host=localhost;Port=5432;Database=AcidFox;Pooling=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasSequence<int>("MemberNumbers", schema: "shared");

            // modelBuilder.Entity<Member>()
            //             .Property(m => m.MemberId)
            //             .HasDefaultValueSql("NEXT VALUE FOR shared.MemberNumbers");

            modelBuilder.Entity<Member>()
                        .ForNpgsqlHasIndex(m => m.MemberId)
                        .IsUnique()
                        .ForNpgsqlInclude(m => m.First_Name)
                        .ForNpgsqlInclude(m => m.Last_Name);
        }
    }
}
