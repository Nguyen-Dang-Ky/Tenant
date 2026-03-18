using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENANT_MANAGEMENT.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }

        [StringLength(10)]
        public string HoadonBusinessCode { get; set; } = string.Empty;

        //Navigation N-1 voi PhongTro
        [ForeignKey("MaPhongTro")]
        public int MaPhongTro { get; set; }
        public PhongTro PhongTro { get; set; } = null!;

        //Navigation 1-N voi ChiTietHoaDon
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

        public DateOnly ThangHoaDon { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TongTien { get; set; }

        public enum Status
        {
            Unpaid = 0,
            Paid = 1
        }
        public Status TrangThai { get; set; }

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
