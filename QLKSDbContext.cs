namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLKSDbContext : DbContext
    {
        public QLKSDbContext()
            : base("name=QLKS")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BAO_CAO_DOANH_THU> BAO_CAO_DOANH_THU { get; set; }
        public virtual DbSet<CTIET_Payment> CTIET_Payment { get; set; }
        public virtual DbSet<CTIET_Renting> CTIET_Renting { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Renting> Rentings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<THAM_SO> THAM_SO { get; set; }
        public virtual DbSet<Type_Cus> Type_Cus { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<BAO_CAO_DOANH_THU>()
                .Property(e => e.MaBaoCao)
                .IsUnicode(false);

            modelBuilder.Entity<BAO_CAO_DOANH_THU>()
                .Property(e => e.TenLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<BAO_CAO_DOANH_THU>()
                .Property(e => e.DoanhThu)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BAO_CAO_DOANH_THU>()
                .Property(e => e.TyLe)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTIET_Payment>()
                .Property(e => e.MaChiTietHD)
                .IsUnicode(false);

            modelBuilder.Entity<CTIET_Payment>()
                .Property(e => e.MaHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<CTIET_Payment>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTIET_Payment>()
                .Property(e => e.ThanhTien)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTIET_Payment>()
                .Property(e => e.NgayThanhToan)
                .IsFixedLength();

            modelBuilder.Entity<CTIET_Payment>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<CTIET_Renting>()
                .Property(e => e.MaChiTietPT)
                .IsUnicode(false);

            modelBuilder.Entity<CTIET_Renting>()
                .Property(e => e.MaPhieuThue)
                .IsUnicode(false);

            modelBuilder.Entity<CTIET_Renting>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.MaHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.TriGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Renting>()
                .Property(e => e.MaPhieuThue)
                .IsUnicode(false);

            modelBuilder.Entity<Renting>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.MaLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.TenPhong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THAM_SO>()
                .Property(e => e.PhuThu)
                .HasPrecision(18, 0);

            modelBuilder.Entity<THAM_SO>()
                .Property(e => e.SoLuongLoaiPhong)
                .IsUnicode(false);

            modelBuilder.Entity<THAM_SO>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);
        }
    }
}
