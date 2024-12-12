using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoanVien.Areas.Admin.Data
{
    public class DoanVienVM
    {
        public int? MaDoanVien { get; set; }
        public string HoTen { get; set; }
        public string Anh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public DateTime? NgayVao { get; set; }

        public int? MaChiDoan { get; set; }
        public string TenChiDoan { get; set; }
    }
}