using System.ComponentModel.DataAnnotations;

namespace TENANT_MANAGEMENT.Models
{
    public class DangNhap
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; } = string.Empty;

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}
