using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShopBridgeModels;

#nullable disable

namespace ShopBridgeRepository.ShopBridgeContexts
{
    public partial class ShopBridgeContext : DbContext
    {
        public ShopBridgeContext()
        {
        }

        public ShopBridgeContext(DbContextOptions<ShopBridgeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<lkpInventoryType> lkpInventoryTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QNDUQ9R; Initial Catalog=ShopBridge; User ID=anku_user;Password=anku_user");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.InventoryDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InventoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.HasOne(d => d.InventoryTypeNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InventoryType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_InventoryType");
            });

            modelBuilder.Entity<lkpInventoryType>(entity =>
            {
                entity.HasKey(e => e.IT_ID)
                    .HasName("PK__lkpInven__6C6BDF4B473ED640");

                entity.Property(e => e.IT_Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InventoryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
