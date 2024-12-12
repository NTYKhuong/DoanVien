using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDoanVien.Areas.Admin.Data;
using QuanLyDoanVien.Models;

namespace QuanLyDoanVien.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private DBDoanVienContext _context = new DBDoanVienContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var lstDV = (from dv in _context.DoanViens
                         join cd in _context.ChiDoans on dv.MaChiDoan equals cd.MaChiDoan
                         
                         orderby dv.MaDoanVien ascending
                         select new DoanVienVM()
                         {
                            
                             MaDoanVien = dv.MaDoanVien,
                             HoTen = dv.HoTen,
                             Anh = dv.Anh,
                             NgaySinh = dv.NgaySinh,
                             DiaChi = dv.DiaChi,
                             SDT = dv.SoDienThoai,
                             NgayVao = dv.NgayVaoDoan,
                             TenChiDoan = cd.TenChiDoan,
                           
                         }).ToList();

            return View(lstDV);
        }
    }
}