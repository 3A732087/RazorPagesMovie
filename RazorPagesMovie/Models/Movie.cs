using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        //使用者不需要在 [日期] 欄位中輸入時間資訊。只會顯示日期，不會顯示時間資訊。
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        //類型
        public string Genre { get; set; } = string.Empty;
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
    }
}
