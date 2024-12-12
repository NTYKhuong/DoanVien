using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDoanVien.Areas.Admin.Data
{
    public class ChiDoanVM
    {
        public int? MaChiDoan {  get; set; }
        public string TenChiDoan { get; set; }
        public string Anh {  get; set; }
        public DateTime? NgayLap { get; set; }

    }
}