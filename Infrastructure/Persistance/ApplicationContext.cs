using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StoreBackendClean.Domain.Entity;
using StoreBackendClean.Infrastructure.Persistance.configuration;

namespace StoreBackendClean.Infrastructure.Persistance {

    public partial class ApplicationContext : DbContext {

        public ApplicationContext() {}

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
            
        }

        public virtual DbSet<Box> Boxes { get; set; } = null!;
        public virtual DbSet<BoxItem> BoxItems { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<StoreItem> StoreItems { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            OnModelCreatingPartial(PersistanceBuilder.Build(modelBuilder));

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        
    }
}
