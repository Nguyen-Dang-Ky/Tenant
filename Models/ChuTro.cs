using System.ComponentModel.DataAnnotations;

namespace TENANT_MANAGEMENT.Models
{
    public class ChuTro
    {
        [Key]
        public int MaChuTro { get; set; }

        [StringLength(100)]
        public string HoVaTen { get; set; } = string.Empty;

        [StringLength(15)]
        public string SoDienThoai { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string DiaChi { get; set; } = string.Empty;
        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        // Navigation 1-N
        public ICollection<KhuTro> KhuTros { get; set; } = new List<KhuTro>();
    }
}
