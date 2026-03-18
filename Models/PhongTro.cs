using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENANT_MANAGEMENT.Models
{
    public class PhongTro
    {
        [Key]
        public int MaPhongTro { get; set; }

        [StringLength(10)]
        public string PhongtroBusinessCode { get; set; } = string.Empty;

        //Navigation voi KhuTro N-1
        public int MaKhuTro { get; set; }
        [ForeignKey("MaKhuTro")]
        public KhuTro KhuTro { get; set; } = null!;

        //Navigation voi HopDong 1-N
        public ICollection<HopDong> CacHopDong { get; set; } = new List<HopDong>();

        //Navigation voi HoaDon 1-N
        public ICollection<HoaDon> CacHoaDon { get; set; } = new List<HoaDon>();


        [Column(TypeName ="decimal(10,2)")]
        public decimal DienTich { get; set; }

        [Column(TypeName ="decimal(12,2)")]
        public decimal GiaPhong { get; set; }

        public enum TrangThaiCuaPhong
        {
            Available = 1,
            Occupied = 2,
            Maintenance = 3
        }
        public TrangThaiCuaPhong TrangThai { get; set; } = TrangThaiCuaPhong.Available;

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
