using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Insurance.Models;

namespace Insurance.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Insurance.Models.Agent> Agent { get; set; }
        public DbSet<Insurance.Models.User> User { get; set; }
        public DbSet<Insurance.Models.Policy> Policy { get; set; }
        public DbSet<Insurance.Models.CascoPolicy> CascoPolicy { get; set; }
        public DbSet<Insurance.Models.HealthPolicy> HealthPolicy { get; set; }
        public DbSet<Insurance.Models.TravelPolicy> TravelPolicy { get; set; }
        public DbSet<Insurance.Models.Case> Case { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Policy>()
                .HasOne<Agent>(p => p.Agent)
                .WithMany(p => p.Policies)
                .HasForeignKey(p => p.AgentId);

            builder.Entity<Policy>()
               .HasOne<User>(p => p.Owner)
               .WithMany(p => p.Policies)
               .HasForeignKey(p => p.OwnerId);

            builder.Entity<Case>()
                .HasOne<User>(p => p.User)
                .WithMany(p => p.Cases)
                .HasForeignKey(p => p.UserId);

            builder.Entity<Policy>()
                .HasOne(a => a.CP)
                .WithOne(b => b.Policy)
                .HasForeignKey<CascoPolicy>(b => b.PolicyId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Policy>()
                .HasOne(a => a.HP)
                .WithOne(b => b.Policy)
                .HasForeignKey<HealthPolicy>(b => b.PolicyId).OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Policy>()
                .HasOne(a => a.TP)
                .WithOne(b => b.Policy)
                .HasForeignKey<TravelPolicy>(b => b.PolicyId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
