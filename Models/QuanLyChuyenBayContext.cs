using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ococ.Models;

public partial class QuanLyChuyenBayContext : DbContext
{
    public QuanLyChuyenBayContext()
    {
    }

    public QuanLyChuyenBayContext(DbContextOptions<QuanLyChuyenBayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chuyenbay> Chuyenbays { get; set; }

    public virtual DbSet<CtCb> CtCbs { get; set; }

    public virtual DbSet<Hanhkhach> Hanhkhaches { get; set; }

    public virtual DbSet<Maybay> Maybays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=anhyeuem;database=QuanLyChuyenBay");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chuyenbay>(entity =>
        {
            entity.HasKey(e => e.Mach).HasName("PRIMARY");

            entity.ToTable("chuyenbay");

            entity.HasIndex(e => e.Mamb, "MAMB");

            entity.Property(e => e.Mach)
                .HasMaxLength(10)
                .HasColumnName("MACH");
            entity.Property(e => e.Chuyen)
                .HasMaxLength(255)
                .HasColumnName("CHUYEN");
            entity.Property(e => e.Dden)
                .HasMaxLength(255)
                .HasColumnName("DDEN");
            entity.Property(e => e.Ddi)
                .HasMaxLength(255)
                .HasColumnName("DDI");
            entity.Property(e => e.Gbay)
                .HasMaxLength(20)
                .HasColumnName("GBAY");
            entity.Property(e => e.Gden)
                .HasMaxLength(20)
                .HasColumnName("GDEN");
            entity.Property(e => e.Mamb)
                .HasMaxLength(10)
                .HasColumnName("MAMB");
            entity.Property(e => e.Ngay)
                .HasMaxLength(20)
                .HasColumnName("NGAY");
            entity.Property(e => e.Thuong).HasColumnName("THUONG");
            entity.Property(e => e.Vip).HasColumnName("VIP");

            entity.HasOne(d => d.Maybay).WithMany(p => p.Chuyenbays)
                .HasForeignKey(d => d.Mamb)
                .HasConstraintName("chuyenbay_ibfk_1");
        });

        modelBuilder.Entity<CtCb>(entity =>
        {
            entity.HasKey(e => new { e.Mach, e.Mahk }).HasName("PRIMARY");

            entity.ToTable("ct_cb");

            entity.HasIndex(e => e.Mahk, "MAHK");

            entity.Property(e => e.Mach)
                .HasMaxLength(10)
                .HasColumnName("MACH");
            entity.Property(e => e.Mahk)
                .HasMaxLength(10)
                .HasColumnName("MAHK");
            entity.Property(e => e.Loaighe).HasColumnName("LOAIGHE");
            entity.Property(e => e.Soghe)
                .HasMaxLength(5)
                .HasColumnName("SOGHE");

            entity.HasOne(d => d.ChuyenBay).WithMany(p => p.CtCbs)
                .HasForeignKey(d => d.Mach)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ct_cb_ibfk_1");

            entity.HasOne(d => d.HanhKhach).WithMany(p => p.CtCbs)
                .HasForeignKey(d => d.Mahk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ct_cb_ibfk_2");
        });

        modelBuilder.Entity<Hanhkhach>(entity =>
        {
            entity.HasKey(e => e.Mahk).HasName("PRIMARY");

            entity.ToTable("hanhkhach");

            entity.Property(e => e.Mahk)
                .HasMaxLength(10)
                .HasColumnName("MAHK");
            entity.Property(e => e.Diachi)
                .HasMaxLength(255)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Dienthoai)
                .HasMaxLength(15)
                .HasColumnName("DIENTHOAI");
            entity.Property(e => e.Hoten)
                .HasMaxLength(255)
                .HasColumnName("HOTEN");
        });

        modelBuilder.Entity<Maybay>(entity =>
        {
            entity.HasKey(e => e.Mamb).HasName("PRIMARY");

            entity.ToTable("maybay");

            entity.Property(e => e.Mamb)
                .HasMaxLength(10)
                .HasColumnName("MAMB");
            entity.Property(e => e.Hangmb)
                .HasMaxLength(255)
                .HasColumnName("HANGMB");
            entity.Property(e => e.Socho).HasColumnName("SOCHO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
