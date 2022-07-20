using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrganicWeb.Models
{
    public partial class OrganicWebContext : DbContext
    {
        public OrganicWebContext()
        {
        }

        public OrganicWebContext(DbContextOptions<OrganicWebContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<AttributePrice> AttributePrices { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Page> Pages { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Shipper> Shippers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-0MMQTVR; Database = OrganicWeb; Integrated Security = true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role_Account");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<AttributePrice>(entity =>
            {
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributePrices)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_Attribute_AttributePrice");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AttributePrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_AttributePrice");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CateId)
                    .HasName("PK__Categori__27638D14EAA64B41");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CateName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(255);

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Thumb).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Category_Category");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Avartar).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FullName).HasMaxLength(255);

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(8)
                    .IsFixedLength();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_Location_Customer");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.NameWithType).HasMaxLength(255);

                entity.Property(e => e.PathWithType).HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(255);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Location_Location");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.PostId)
                    .HasName("PK__News__AA126018E59DBDCD");

                entity.Property(e => e.Alias).HasMaxLength(255);

                entity.Property(e => e.Author).HasMaxLength(255);

                entity.Property(e => e.IsHot)
                    .HasColumnName("isHot")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsNewFeed)
                    .HasColumnName("isNewFeed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ShortContents).HasMaxLength(500);

                entity.Property(e => e.Thumb).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_Account_New");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_Category_New");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Customer");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK_OrderStatus_Order");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Order_OrderDetail");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_OrderDetail");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("OrderStatus");

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.PageName).HasMaxLength(250);

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Thumb).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetaDesc).HasMaxLength(255);

                entity.Property(e => e.MetaKey).HasMaxLength(255);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.ShortDesc).HasMaxLength(255);

                entity.Property(e => e.Tags).HasMaxLength(500);

                entity.Property(e => e.Thumb).HasMaxLength(500);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Video).HasMaxLength(500);

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK_Category_Product");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.RoleName).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.Property(e => e.Company).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.ShipperName).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
