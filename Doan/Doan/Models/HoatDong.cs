namespace Doan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoatDong")]
    public partial class HoatDong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoatDong()
        {
            ThamGiaHoatDongs = new HashSet<ThamGiaHoatDong>();
        }

        [Key]
        public int MaHoatDong { get; set; }

        [Required]
        [StringLength(100)]
        public string TenHoatDong { get; set; }

        [StringLength(255)]
        public string Anh { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayDienRa { get; set; }

        [StringLength(255)]
        public string DiaDiem { get; set; }

        public string MoTa { get; set; }

        public int? MaChiDoan { get; set; }

        public virtual ChiDoan ChiDoan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThamGiaHoatDong> ThamGiaHoatDongs { get; set; }
    }
}
