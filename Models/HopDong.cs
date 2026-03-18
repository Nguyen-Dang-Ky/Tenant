using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENANT_MANAGEMENT.Models
{
    public class HopDong
    {
        [Key]
        public int MaHopDong { get; set; }

        [StringLength(10)]
        public string HopdongBusinessCode { get; set; } = string.Empty;
        
        //Navigation voi PhongTro
        [Required]
        public int MaPhongTro { get; set; }
        [ForeignKey("MaPhongTro")]
        public PhongTro PhongTro { get; set; } = null!;

        //Navigation voi KhachThue
        public int MaKhachThue { get; set; }
        public KhachThue KhachThue { get; set; } = null!;

        public DateOnly NgayBatDau { get; set; }
        public DateOnly NgayKetThuc { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal TienCoc { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TienThueHangThang { get; set; }

        public enum TrangThaiHopDong { 
            Active = 1,
            Expired = 2,
            Terminated = 3
        }
        public TrangThaiHopDong TrangThai { get; set; } = TrangThaiHopDong.Active;

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
