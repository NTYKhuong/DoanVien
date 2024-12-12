using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace TTDoanVien.Models
{
    public partial class DatabaseDV : DbContext
    {
        public DatabaseDV()
            : base("name=DatabaseDV")
        {
        }

        public virtual DbSet<ChiDoan> ChiDoans { get; set; }
        public virtual DbSet<DoanVien> DoanViens { get; set; }
        public virtual DbSet<HoatDong> HoatDongs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThamGiaHoatDong> ThamGiaHoatDongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
