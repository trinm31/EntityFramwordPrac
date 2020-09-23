using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fluent_API.Model
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
    
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    
        [StringLength(50)]
        public string Provider { get; set; }
        
        public int? UserPostId {set;  get;}         // Lưu thông tin người Post sản phẩm
        public virtual User UserPost {set; get;}    // Tham chiếu User
    }
    
}