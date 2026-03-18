using System.ComponentModel.DataAnnotations;

namespace TENANT_MANAGEMENT.Models
{
    public class KhachThue
    {
        [Key]
        public int MaKhachThue { get; set; } //Primary Key

        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(20)]
        public string CCCD { get; set; } = string.Empty; // Dùng Unique

        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        public enum Gender
        {
            Male = 1,
            Female = 2,
            Other = 3
        }
        public Gender GioiTinh { get; set; }

        public DateOnly NgaySinh { get; set; } 

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; } = string.Empty;

        public DateTime ThoiGianTao { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        
        public ICollection<HopDong> HopDong { get; set; } = new List<HopDong>();
    }
}
