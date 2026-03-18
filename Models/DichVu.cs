using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENANT_MANAGEMENT.Models
{
    public class DichVu
    {
        [Key]
        public int MaDV { get; set; }
        
        [StringLength(20)]
        public string? TenDV { get; set; }
        
        [StringLength(20)]
        public string? DonVi { get; set; }
        
        [Column(TypeName ="decimal(12,2)")]
        public decimal? GiaDV { get; set; }

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
