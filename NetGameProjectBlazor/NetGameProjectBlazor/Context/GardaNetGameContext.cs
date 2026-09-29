using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetGameProjectBlazor.Entities;
using NetGameProjectBlazor.Context;
using NetGameProjectBlazor.Data;

namespace NetGameProjectBlazor.Context;

public partial class GardaNetGameContext : DbContext
{
    public GardaNetGameContext()
    {
    }

    public GardaNetGameContext(DbContextOptions<GardaNetGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Pegi> Pegis { get; set; }

    public virtual DbSet<PhysicalProduct> PhysicalProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=NetGameDB;User=root;Password=Password123;AllowPublicKeyRetrieval=True;", ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=NetGameDB;User=root;Password=Password123;AllowPublicKeyRetrieval=True;"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC079984A556");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D105349A14780D").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC074C373A1E");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D1053425A4DF06").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phonenumber).HasMaxLength(20);
            entity.Property(e => e.RegistrationDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC07B227EF39");

            entity.ToTable("Discount");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Discount1).HasColumnName("Discount");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Event__3214EC07DB5D86BD");

            entity.ToTable("Event");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Game__3214EC07AA046B5A");

            entity.ToTable("Game");

            entity.HasIndex(e => e.ProductId, "UQ__Game__B40CC6CC79EB4072").IsUnique();

            entity.HasOne(d => d.Pegi).WithMany(p => p.Games)
                .HasForeignKey(d => d.PegiId)
                .HasConstraintName("FK__Game__PegiId__06CD04F7");

            entity.HasOne(d => d.Product).WithOne(p => p.Game)
                .HasForeignKey<Game>(d => d.ProductId)
                .HasConstraintName("FK__Game__ProductId__07C12930");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genre__3214EC0794F61077");

            entity.ToTable("Genre");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasMany(d => d.Games).WithMany(p => p.Genres)
                .UsingEntity<Dictionary<string, object>>(
                    "GameGenre",
                    r => r.HasOne<Game>().WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GameGenre__GameI__0B91BA14"),
                    l => l.HasOne<Genre>().WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GameGenre__Genre__0A9D95DB"),
                    j =>
                    {
                        j.HasKey("GenreId", "GameId").HasName("PK__GameGenr__C12E8C01A768B2B6");
                        j.ToTable("GameGenre");
                    });
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC0770BF6A81");

            entity.ToTable("Order");

            entity.Property(e => e.CustomerId).HasMaxLength(450);
            entity.Property(e => e.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_ApplicationUser_CustomerId");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC07936B5690");

            entity.ToTable("OrderItem");

            entity.Property(e => e.PriceAtPurchase).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Order__04E4BC85");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderItem__Produ__05D8E0BE");
        });

        modelBuilder.Entity<Pegi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PEGI__3214EC07B21FCFC4");

            entity.ToTable("PEGI");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Age).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<PhysicalProduct>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PhysicalProduct");

            entity.HasIndex(e => e.ProductId, "UQ__Physical__B40CC6CCAC7B6C09").IsUnique();

            entity.HasOne(d => d.Product).WithOne()
                .HasForeignKey<PhysicalProduct>(d => d.ProductId)
                .HasConstraintName("FK__PhysicalP__Produ__08B54D69");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0714803B02");

            entity.ToTable("Product");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductImageUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3214EC07615A5AFD");

            entity.ToTable("Review");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.CustomerId).HasMaxLength(450);

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Review__Customer__02FC7413");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Review__ProductI__02084FDA");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shopping__3214EC072377E429");

            entity.ToTable("ShoppingCart");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
            entity.Property(e => e.CustomerId).HasMaxLength(450);

            entity.HasOne(d => d.Customer).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__Custo__09A971A2");
        });

        modelBuilder.Entity<ShoppingCartItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shopping__3214EC07EF799F7D");

            entity.ToTable("ShoppingCartItem");

            entity.Property(e => e.PriceAtPurchase).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Cart).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__CartI__00200768");

            entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ShoppingC__Produ__01142BA1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
