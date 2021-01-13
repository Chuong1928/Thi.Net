namespace NgoQuyTruong.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LIENLAC")]
    public partial class LIENLAC
    {
        [Key]
        [StringLength(50)]
        public string MaLienLac { get; set; }

        public string TenGoi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? SoDienThoai { get; set; }

        [Required]
        [StringLength(50)]
        public string MaNhom { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }
    }
}
