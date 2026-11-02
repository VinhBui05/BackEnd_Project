using System.ComponentModel.DataAnnotations;

namespace BackEnd_Project.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên pizza")]
        [Display(Name = "Tên Pizza")]
        [StringLength(100, ErrorMessage = "Tên pizza không được vượt quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập giá")]
        [Range(10000, 1000000, ErrorMessage = "Giá phải từ 10.000 đến 1.000.000 VNĐ")]
        [Display(Name = "Giá (VNĐ)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập danh mục")]
        [Display(Name = "Danh mục")]
        public string Category { get; set; } = string.Empty;

        [Display(Name = "Mô tả")]
        [StringLength(500, ErrorMessage = "Mô tả không được vượt quá 500 ký tự")]
        public string? Description { get; set; }
    }
}