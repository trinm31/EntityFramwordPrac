using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scaford.Models
{
    public partial class Sanpham
    {
        [Key]
        [Column("SanphamID")]
        public int SanphamId { get; set; }
        [StringLength(255)]
        public string TenSanpham { get; set; }
    }
}
