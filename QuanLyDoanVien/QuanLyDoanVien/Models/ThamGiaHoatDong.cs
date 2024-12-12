namespace QuanLyDoanVien.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThamGiaHoatDong")]
    public partial class ThamGiaHoatDong
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDoanVien { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHoatDong { get; set; }

        public DateTime? ThoiGianThamGia { get; set; }

        public virtual DoanVien DoanVien { get; set; }

        public virtual HoatDong HoatDong { get; set; }
    }
}
