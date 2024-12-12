using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTDoanVien.Areas.Admin.Data;
using TTDoanVien.Models;

namespace TTDoanVien.Areas.Admin.Controllers
{
    public class DoanVienController : Controller
    {
        // GET: Admin/DoanVien
        private DatabaseDV _context = new DatabaseDV();
        public ActionResult Index()
        {
            var lstDV = (from dv in _context.DoanViens
                         join cd in _context.ChiDoans on dv.MaChiDoan equals cd.MaChiDoan
            orderby dv.MaDoanVien ascending
                         select new DoanVienMV()
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

        private SelectList GetChiDoanList(object selectedValue = null)
        {
            var lstChiDoan = _context.ChiDoans.OrderBy(x => x.TenChiDoan).ToList();
            return new SelectList(lstChiDoan, "MaChiDoan", "TenChiDoan", selectedValue);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var doanVien = _context.DoanViens.Find(id);
            if (doanVien == null)
                return HttpNotFound();

            ViewBag.MaChiDoan = GetChiDoanList(doanVien.MaChiDoan);

            var model = new DoanVienMV
            {
                MaDoanVien = doanVien.MaDoanVien,
                HoTen = doanVien.HoTen,
                Anh = doanVien.Anh,
                NgaySinh = doanVien.NgaySinh,
                DiaChi = doanVien.DiaChi,
                SDT = doanVien.SoDienThoai,
                NgayVao = doanVien.NgayVaoDoan,
                MaChiDoan = doanVien.MaChiDoan
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DoanVienMV formData, HttpPostedFileBase fileUpload)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MaChiDoan = GetChiDoanList(formData.MaChiDoan);
                return View(formData);
            }

            var doanVien = _context.DoanViens.Find(formData.MaDoanVien);
            if (doanVien == null)
                return HttpNotFound();

            doanVien.HoTen = formData.HoTen;
            doanVien.NgaySinh = formData.NgaySinh;
            doanVien.DiaChi = formData.DiaChi;
            doanVien.SoDienThoai = formData.SDT;
            doanVien.NgayVaoDoan = formData.NgayVao;
            doanVien.MaChiDoan = formData.MaChiDoan;

            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                var extension = Path.GetExtension(fileUpload.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Server.MapPath("~/Image/Hinh/"), uniqueFileName);

                // Kiểm tra nếu ảnh đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ModelState.AddModelError("fileUpload", "Ảnh đã tồn tại!");
                    ViewBag.MaChiDoan = GetChiDoanList(formData.MaChiDoan);
                    return View(formData);
                }

                fileUpload.SaveAs(path);
                doanVien.Anh = uniqueFileName; // Lưu tên file ảnh vào model
            }

            _context.Entry(doanVien).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            // Lấy danh sách chi đoàn và trả về view
            ViewBag.MaChiDoan = GetChiDoanList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoanVienMV formData, HttpPostedFileBase fileUpload)
        {
            if (!ModelState.IsValid)
            {
                // Nếu form không hợp lệ, lấy lại danh sách chi đoàn và trả về view
                ViewBag.MaChiDoan = GetChiDoanList(formData.MaChiDoan);
                return View(formData);
            }

            var doanVien = new DoanVien
            {
                HoTen = formData.HoTen,
                NgaySinh = formData.NgaySinh,
                DiaChi = formData.DiaChi,
                SoDienThoai = formData.SDT,
                NgayVaoDoan = formData.NgayVao,
                MaChiDoan = formData.MaChiDoan
            };

            // Xử lý tải ảnh nếu có
            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileNameWithoutExtension(fileUpload.FileName);
                var extension = Path.GetExtension(fileUpload.FileName);
                var uniqueFileName = $"{fileName}_{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Server.MapPath("~/Image/Hinh/"), uniqueFileName);

                // Kiểm tra nếu ảnh đã tồn tại
                if (System.IO.File.Exists(path))
                {
                    ModelState.AddModelError("fileUpload", "Ảnh đã tồn tại!");
                    ViewBag.MaChiDoan = GetChiDoanList(formData.MaChiDoan);
                    return View(formData);
                }

                fileUpload.SaveAs(path);
                doanVien.Anh = uniqueFileName; // Lưu tên file ảnh vào model
            }

            // Thêm đoàn viên vào cơ sở dữ liệu và lưu
            _context.DoanViens.Add(doanVien);
            _context.SaveChanges();

            // Chuyển hướng về danh sách đoàn viên sau khi thêm thành công
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var doanVien = _context.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }

            var model = new DoanVienMV
            {
                MaDoanVien = doanVien.MaDoanVien,
                HoTen = doanVien.HoTen,
                Anh = doanVien.Anh,
                NgaySinh = doanVien.NgaySinh,
                DiaChi = doanVien.DiaChi,
                SDT = doanVien.SoDienThoai,
                NgayVao = doanVien.NgayVaoDoan,
                TenChiDoan = _context.ChiDoans.Where(x => x.MaChiDoan == doanVien.MaChiDoan).Select(x => x.TenChiDoan).FirstOrDefault()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (!id.HasValue)
            {
                return HttpNotFound();
            }

            var doanVien = _context.DoanViens.Find(id);
            if (doanVien == null)
            {
                return HttpNotFound();
            }

            // Xóa ảnh (nếu có)
            var imagePath = Server.MapPath("~/Image/Hinh/" + doanVien.Anh);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            // Xóa đoàn viên khỏi cơ sở dữ liệu
            _context.DoanViens.Remove(doanVien);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
