using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTDoanVien.Areas.Admin.Data
{
    public class ChiDoanMV
    {
        public int? MaChiDoan { get; set; }
        public string TenChiDoan { get; set; }
        public string Anh { get; set; }
        public DateTime? NgayLap { get; set; }
    }
}