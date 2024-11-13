using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WF.DAL.Models
{
    public partial class QuanLyBanSachContext : DbContext
    {
        public QuanLyBanSachContext()
        {
        }

        public QuanLyBanSachContext(DbContextOptions<QuanLyBanSachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<HoaDonCt> HoaDonCts { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; } = null!;
        public virtual DbSet<NhanVien> NhanViens { get; set; } = null!;
        public virtual DbSet<Sach> Saches { get; set; } = null!;
        public virtual DbSet<SachChiTiet> SachChiTiets { get; set; } = null!;
        public virtual DbSet<Voucher> Vouchers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-60F7530\\SQLEXPRESS;Database=QuanLyBanSach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HoaDon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idkhachhang).HasColumnName("IDKhachhang");

                entity.Property(e => e.Idnhanvien).HasColumnName("IDNhanvien");

                entity.Property(e => e.Idvoucher).HasColumnName("IDVoucher");

                entity.Property(e => e.MaHd)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayMuaHang).HasColumnType("datetime");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.IdkhachhangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idkhachhang)
                    .HasConstraintName("FK__HoaDon__IDKhachh__1ED998B2");

                entity.HasOne(d => d.IdnhanvienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idnhanvien)
                    .HasConstraintName("FK__HoaDon__IDNhanvi__1DE57479");

                entity.HasOne(d => d.IdvoucherNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.Idvoucher)
                    .HasConstraintName("FK__HoaDon__IDVouche__1FCDBCEB");
            });

            modelBuilder.Entity<HoaDonCt>(entity =>
            {
                entity.ToTable("HoaDonCt");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdhoaDon).HasColumnName("IDHoaDon");

                entity.Property(e => e.IdsachCt).HasColumnName("IDSachCt");

                entity.Property(e => e.MaHdct)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaSpct)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TenSp).HasMaxLength(100);

                entity.HasOne(d => d.IdhoaDonNavigation)
                    .WithMany(p => p.HoaDonCts)
                    .HasForeignKey(d => d.IdhoaDon)
                    .HasConstraintName("FK__HoaDonCt__IDHoaD__239E4DCF");

                entity.HasOne(d => d.IdsachCtNavigation)
                    .WithMany(p => p.HoaDonCts)
                    .HasForeignKey(d => d.IdsachCt)
                    .HasConstraintName("FK__HoaDonCt__IDSach__22AA2996");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.MaKhachHang)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sđt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SĐT");

                entity.Property(e => e.TenKhachHang).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaXuatBan>(entity =>
            {
                entity.ToTable("NhaXuatBan");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.MaNxb)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNXB");

                entity.Property(e => e.NamXb)
                    .HasColumnType("datetime")
                    .HasColumnName("NamXB");

                entity.Property(e => e.Sđt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SĐT");

                entity.Property(e => e.TenNxb)
                    .HasMaxLength(50)
                    .HasColumnName("TenNXB");

                entity.Property(e => e.TrangThai).HasMaxLength(30);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.ToTable("NhanVien");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cccd)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CCCD");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GioiTinh).HasMaxLength(10);

                entity.Property(e => e.HoTenNv)
                    .HasMaxLength(50)
                    .HasColumnName("HoTenNV");

                entity.Property(e => e.MaNv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MaNV");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.Sđt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SĐT");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TenTK");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.Property(e => e.VaiTro).HasMaxLength(30);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.ToTable("Sach");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaSach)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.NgonNgu).HasMaxLength(20);

                entity.Property(e => e.TacGia).HasMaxLength(200);

                entity.Property(e => e.TieuDe).HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasMaxLength(50);
            });

            modelBuilder.Entity<SachChiTiet>(entity =>
            {
                entity.ToTable("SachChiTiet");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Idnxb).HasColumnName("IDNXB");

                entity.Property(e => e.Idsach).HasColumnName("IDSach");

                entity.Property(e => e.MaSachCt)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Tap).HasMaxLength(100);

                entity.Property(e => e.TenTheLoai).HasMaxLength(200);

                entity.HasOne(d => d.IdnxbNavigation)
                    .WithMany(p => p.SachChiTiets)
                    .HasForeignKey(d => d.Idnxb)
                    .HasConstraintName("FK__SachChiTi__IDNXB__1B0907CE");

                entity.HasOne(d => d.IdsachNavigation)
                    .WithMany(p => p.SachChiTiets)
                    .HasForeignKey(d => d.Idsach)
                    .HasConstraintName("FK__SachChiTi__IDSac__1A14E395");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaVoucher)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NgayBatDau).HasColumnType("datetime");

                entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
