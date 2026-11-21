using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaoBinh_241230664_de2023.Models
{
    [ModelMetadataType(typeof(HangHoaMetadata))]
    public partial class HangHoa { }

    public class HangHoaMetadata
    {
        [Required(ErrorMessage = "Loại hàng không được để trống")]
        [Display(Name = "loại hàng")]
        public string MaLoai { get; set; }

        [Required(ErrorMessage = "Tên hàng không được để trống")]
        [StringLength(50, ErrorMessage = "Tên hàng không được vượt quá 50 ký tự")]
        public string TenHang { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(100, 5000, ErrorMessage = "Giá phải nằm trong khoảng từ 100 đến 5000")]
        public decimal? Gia { get; set; }

        [RegularExpression(@"(?i)^.+\.(jpg|jpeg|png|webp)$",
            ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
        public string? Anh { get; set; }
    }
}
