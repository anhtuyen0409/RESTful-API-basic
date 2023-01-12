namespace TestAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        public int MaSP { get; set; }

        [StringLength(255)]
        public string TenSP { get; set; }

        public int? DonGia { get; set; }

        public int? MaLoai { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
