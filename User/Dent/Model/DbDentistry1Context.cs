using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Dent.Model;

public partial class DbDentistry1Context : DbContext
{
    public DbDentistry1Context()
    {
    }

    public DbDentistry1Context(DbContextOptions<DbDentistry1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Entry> Entries { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServicesType> ServicesTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=db_dentistry", ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Entry>(entity =>
        {
            entity.HasKey(e => e.EntryId).HasName("PRIMARY");

            entity.ToTable("entry");

            entity.Property(e => e.EntryId).HasColumnName("entry_id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("date_time");
            entity.Property(e => e.EntryStatus)
                .HasMaxLength(11)
                .HasColumnName("entry_status");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .HasColumnName("user_email");
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PRIMARY");

            entity.ToTable("manager");

            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.ManagerPassword)
                .HasMaxLength(64)
                .HasColumnName("manager_password");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.NewsId).HasName("PRIMARY");

            entity.ToTable("news");

            entity.Property(e => e.NewsId).HasColumnName("news_id");
            entity.Property(e => e.DatePublish).HasColumnName("date_publish");
            entity.Property(e => e.NewsDesc)
                .HasColumnType("text")
                .HasColumnName("news_desc");
            entity.Property(e => e.NewsImage)
                .HasMaxLength(70)
                .HasColumnName("news_image");
            entity.Property(e => e.NewsTitle)
                .HasMaxLength(100)
                .HasColumnName("news_title");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewsId).HasName("PRIMARY");

            entity.ToTable("reviews");

            entity.Property(e => e.ReviewsId).HasColumnName("reviews_id");
            entity.Property(e => e.ReviewsDate)
                .HasColumnType("datetime")
                .HasColumnName("reviews_date");
            entity.Property(e => e.ReviewsText)
                .HasColumnType("text")
                .HasColumnName("reviews_text");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServicesId).HasName("PRIMARY");

            entity.ToTable("services");

            entity.HasIndex(e => e.ServicesTypeId, "fk_services_type_idx");

            entity.Property(e => e.ServicesId).HasColumnName("services_id");
            entity.Property(e => e.ServicesDesc)
                .HasColumnType("text")
                .HasColumnName("services_desc");
            entity.Property(e => e.ServicesPrice).HasColumnName("services_price");
            entity.Property(e => e.ServicesTitle)
                .HasMaxLength(100)
                .HasColumnName("services_title");
            entity.Property(e => e.ServicesTypeId).HasColumnName("services_type_id");

            entity.HasOne(d => d.ServicesType).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServicesTypeId)
                .HasConstraintName("fk_services_type");
        });

        modelBuilder.Entity<ServicesType>(entity =>
        {
            entity.HasKey(e => e.ServicesTypeId).HasName("PRIMARY");

            entity.ToTable("services_type");

            entity.Property(e => e.ServicesTypeId).HasColumnName("services_type_id");
            entity.Property(e => e.ServicesTypeTitle)
                .HasMaxLength(45)
                .HasColumnName("services_type_title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
