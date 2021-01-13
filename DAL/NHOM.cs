namespace NgoQuyTruong.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHOM")]
    public partial class NHOM
    {
        [Key]
        [StringLength(50)]
        public string MaNhom { get; set; }

        [StringLength(50)]
        public string TenNhom { get; set; }
    }
}
