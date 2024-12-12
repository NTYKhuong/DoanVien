using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doan.Models;

namespace Doan.Data
{
    public class DoanVien
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public string Anh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public DateTime NgayVaoDoan { get; set; }
        public int ChiDoanId { get; set; }
        public virtual ChiDoan ChiDoan { get; set; }
    }
}