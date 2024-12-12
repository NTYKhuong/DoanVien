using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDoanVien.Areas.Admin.Data;
using QuanLyDoanVien.Models;

namespace QuanLyDoanVien.Areas.Admin.Controllers
{
    public class HoatDongController : Controller
    {
        // GET: Admin/HoatDong
        private DBDoanVienContext _context = new DBDoanVienContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HoatDong()
        {
            var lstHD = (from hd in _context.HoatDongs
                         join cd in _context.ChiDoans on hd.MaChiDoan equals cd.MaChiDoan

                         orderby hd.MaHoatDong ascending
                         select new HoatDongVM
                         {
                             MaHoatDong = hd.MaHoatDong,
                             TenHoatDong = hd.TenHoatDong,
                             Anh = hd.Anh,
                             NgayDienRa = hd.NgayDienRa,
                             DiaDiem = hd.DiaDiem,
                             MoTa = hd.MoTa,
                             TenChiDoan = cd.TenChiDoan,

                         }).ToList();

            return View(lstHD);
        }

    }
}