using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace QuanLyDoanVien.Areas.Admin.Data
{
    public class HoatDongVM
    {
        public int? MaHoatDong {  get; set; }
        public string TenHoatDong { get; set; }
        public string Anh {  get; set; }
        public DateTime? NgayDienRa { get; set; }
        public string DiaDiem { get; set; }
        public string MoTa {  get; set; }
        public int? MaChiDoan { get; set; }
        public string TenChiDoan { get; set; }
    }
}