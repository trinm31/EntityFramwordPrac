using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
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
    }
    
}