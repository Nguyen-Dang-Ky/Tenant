using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TENANT_MANAGEMENT.Models;

namespace TENANT_MANAGEMENT.Data
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options)
        {

        }

        public DbSet<DangNhap> DangNhaps { get; set; }
        public DbSet<ChuTro> ChuTros { get; set; }
        public DbSet<KhuTro> KhuTros { get; set; }
        public DbSet<PhongTro> PhongTros { get; set; }
        public DbSet<KhachThue> KhachThues { get; set; }
        public DbSet<HopDong> HopDongs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<DichVu> DichVus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangNhap>().HasQueryFilter(dn => !dn.IsDeleted);
            modelBuilder.Entity<ChuTro>().HasQueryFilter(ct => !ct.IsDeleted);
            modelBuilder.Entity<KhuTro>().HasQueryFilter(kt => !kt.IsDeleted);
            modelBuilder.Entity<PhongTro>().HasQueryFilter(pt => !pt.IsDeleted);
            modelBuilder.Entity<KhachThue>().HasQueryFilter(kth => !kth.IsDeleted);
            modelBuilder.Entity<HopDong>().HasQueryFilter(hd => !hd.IsDeleted);
            modelBuilder.Entity<HoaDon>().HasQueryFilter(hdon => !hdon.IsDeleted);
            modelBuilder.Entity<ChiTietHoaDon>().HasQueryFilter(ctiet => !ctiet.IsDeleted);
            modelBuilder.Entity<DichVu>().HasQueryFilter(dv => !dv.IsDeleted);

            modelBuilder.Entity<DangNhap>().HasKey(dn => dn.Id);
            modelBuilder.Entity<ChuTro>().HasKey(ct => ct.MaChuTro);
            modelBuilder.Entity<KhuTro>().HasKey(kt => kt.MaKhuTro);
            modelBuilder.Entity<PhongTro>().HasKey(pt => pt.MaPhongTro);
            modelBuilder.Entity<KhachThue>().HasKey(kth => kth.MaKhachThue);
            modelBuilder.Entity<HopDong>().HasKey(hd => hd.MaHopDong);
            modelBuilder.Entity<HoaDon>().HasKey(hdon => hdon.MaHD);
            modelBuilder.Entity<ChiTietHoaDon>().HasKey(ctiet => ctiet.MaCTHD);
            modelBuilder.Entity<DichVu>().HasKey(dv => dv.MaDV);

            modelBuilder.Entity<KhuTro>()
                .HasOne(kt => kt.ChuTro)
                .WithMany(ct => ct.KhuTros)
                .HasForeignKey(kt => kt.MaChuTro);  //KhuTro - ChuTro

            modelBuilder.Entity<PhongTro>()
                .HasOne(pt => pt.KhuTro)
                .WithMany(kt => kt.PhongTros)
                .HasForeignKey(kt => kt.MaKhuTro);  //PhongTro - KhuTro

            modelBuilder.Entity<HoaDon>()
                .HasOne(hdon=>hdon.PhongTro)
                .WithMany(pt=>pt.CacHoaDon)
                .HasForeignKey(hdon=>hdon.MaPhongTro); //HoaDon - PhongTro

            modelBuilder.Entity<HopDong>()
                .HasOne(hd => hd.PhongTro)
                .WithMany(pt => pt.CacHopDong)
                .HasForeignKey(pt => pt.MaPhongTro);//HopDong - PhongTro
            modelBuilder.Entity<HopDong>()
                .HasOne(hd => hd.KhachThue)
                .WithMany(kt => kt.HopDong)
                .HasForeignKey(kt => kt.MaKhachThue);//HopDong - KhachThue

            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(ctiet => ctiet.HoaDon)
                .WithMany(hdon => hdon.ChiTietHoaDons)
                .HasForeignKey(hdon => hdon.MaHD);  //CTHD-HoaDon
            modelBuilder.Entity<ChiTietHoaDon>()
                .HasOne(ctiet => ctiet.DichVu)
                .WithMany(dv=>dv.ChiTietHoaDons)
                .HasForeignKey(dv=>dv.MaDV);        //CTHD-DV

            //set UNIQUE cho Index quan trọng.
            modelBuilder.Entity<KhachThue>()
                .HasIndex(kt => kt.CCCD)
                .IsUnique();
            modelBuilder.Entity<HoaDon>()
                .HasIndex(hd => new { hd.MaPhongTro, hd.ThangHoaDon })
                .IsUnique();
            modelBuilder.Entity<PhongTro>()
                .HasIndex(p => p.MaKhuTro)
                .IsUnique();
            modelBuilder.Entity<PhongTro>()
                .HasIndex(p => p.PhongtroBusinessCode)
                .IsUnique();
            modelBuilder.Entity<HopDong>()
                .HasIndex(hd => hd.HopdongBusinessCode)
                .IsUnique();
            modelBuilder.Entity<HoaDon>()
                .HasIndex(hdon => hdon.HoadonBusinessCode)
                .IsUnique();




            base.OnModelCreating(modelBuilder);
        }
    }
}
