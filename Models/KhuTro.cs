using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TENANT_MANAGEMENT.Models
{
    public class KhuTro
    {
        [Key]
        public int MaKhuTro { get; set; }

        public int MaChuTro { get; set; }

        [ForeignKey("MaChuTro")]
        public ChuTro ChuTro { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string TenKhuTro { get; set; } = string.Empty;

        [StringLength(200)]
        public string? DiaChi { get; set; }

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        // Navigation 1-N
        public ICollection<PhongTro> PhongTros { get; set; } = new List<PhongTro>();
    }
}
