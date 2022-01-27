using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class DDSXContext : DbContext
    {
        public DDSXContext()
        {
        }

        public DDSXContext(DbContextOptions<DDSXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuongTrinh> ChuongTrinhs { get; set; } = null!;
        public virtual DbSet<DatLich> DatLiches { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<Xe> Xes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SV-CAS-140\\MSSQLSERVER01;Database=DDSX;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuongTrinh>(entity =>
            {
                entity.ToTable("ChuongTrinh");

                entity.Property(e => e.DiaDiem).HasMaxLength(50);

                entity.Property(e => e.TacGia).HasMaxLength(50);

                entity.Property(e => e.TenChuongTrinh).HasMaxLength(50);

                entity.Property(e => e.ThoiGianChieu).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianKetThuc).HasColumnType("datetime");

                entity.HasOne(d => d.PhongNavigation)
                    .WithMany(p => p.ChuongTrinhs)
                    .HasForeignKey(d => d.Phong)
                    .HasConstraintName("FK_ChuongTrinh_Phong");
            });

            modelBuilder.Entity<DatLich>(entity =>
            {
                entity.HasKey(e => e.DatLich1);

                entity.ToTable("DatLich");

                entity.Property(e => e.DatLich1).HasColumnName("DatLich");

                entity.HasOne(d => d.ChuongTrinhNavigation)
                    .WithMany(p => p.DatLiches)
                    .HasForeignKey(d => d.ChuongTrinh)
                    .HasConstraintName("FK_DatLich_ChuongTrinh");

                entity.HasOne(d => d.XeNavigation)
                    .WithMany(p => p.DatLiches)
                    .HasForeignKey(d => d.Xe)
                    .HasConstraintName("FK_DatLich_Xe");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.ToTable("Phong");

                entity.Property(e => e.TenPhong).HasMaxLength(50);
            });

            modelBuilder.Entity<Xe>(entity =>
            {
                entity.ToTable("Xe");

                entity.Property(e => e.NguoiLaiXe).HasMaxLength(50);

                entity.Property(e => e.TenXe).HasMaxLength(50);

                entity.Property(e => e.ThoiGianKhoiHanh).HasColumnType("datetime");

                entity.Property(e => e.ThoiGianVe).HasColumnType("datetime");

                entity.HasOne(d => d.ChuongTrinhNavigation)
                    .WithMany(p => p.Xes)
                    .HasForeignKey(d => d.ChuongTrinh)
                    .HasConstraintName("FK_Xe_ChuongTrinh");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
