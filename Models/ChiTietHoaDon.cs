using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENANT_MANAGEMENT.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }

        //Navigation N-1 voi HD
        public int MaHD { get; set; }
        public HoaDon HoaDon { get; set; } = null!;

        //Navigation N-1 voi DV
        public int MaDV { get; set; }
        public DichVu DichVu { get; set; } = null!;

        [StringLength(100)]
        public string TenDV { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        public int SoLuong { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ThanhTien { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
