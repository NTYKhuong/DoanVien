using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDoanVien.Areas.Admin.Data;
using QuanLyDoanVien.Models;

namespace QuanLyDoanVien.Areas.Admin.Controllers
{

    public class ChiDoanController : Controller
    {
        private DBDoanVienContext _context = new DBDoanVienContext();
        // GET: Admin/ChiDoan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChiDoan() // Đổi tên từ Index thành ChiDoan
        {
            var lstCD = (from cd in _context.ChiDoans
                         orderby cd.MaChiDoan ascending
                         select new ChiDoanVM()
                         {
                            MaChiDoan = cd.MaChiDoan,
                            TenChiDoan = cd.TenChiDoan,
                            Anh = cd.Anh,
                            NgayLap = cd.NgayThanhLap,

                         }).ToList();

            return View(lstCD);
        }
    }
}