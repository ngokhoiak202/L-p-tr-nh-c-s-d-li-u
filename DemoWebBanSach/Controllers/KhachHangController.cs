using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoWebBanSach.Models;
using DemoWebBanSach.Controllers;

namespace DemoWebBanSach.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        public ActionResult DanhSach()
        {
            //1. Lấy ds dữ liệu trong bảng
            BANSACHEntities db = new BANSACHEntities();
            List<KHACHHANG> DSKhachHang = db.KHACHHANGs.ToList();
            return View(DSKhachHang);
        }

        public ActionResult ThemMoi()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult ThemMoi(KHACHHANG model)
        {
            //2. Thêm mới
            BANSACHEntities db = new BANSACHEntities();
            db.KHACHHANGs.Add(model);
            //lưu lại
            db.SaveChanges();

            return RedirectToAction("DanhSach");
        }

        public ActionResult CapNhat(int id)
        {
            //3 tìm đối tượng theo id
            BANSACHEntities db = new BANSACHEntities();
/*            KHACHHANG model = db.KHACHHANGs.SingleOrDefault(m => m.MaKH == MaKH);
*/            KHACHHANG model2 = db.KHACHHANGs.Find(id);
            return View(model2);
        }

        [HttpPost]
        public ActionResult CapNhat(KHACHHANG model)
        {
            BANSACHEntities db = new BANSACHEntities();
            // tìm đối tượng
            var update = db.KHACHHANGs.Find(model.MaKH);
            // gán giá trị
            update.HoTenKH = model.HoTenKH;
            update.DiachiKH = model.DiachiKH;
            update.DienthoaiKH = model.DienthoaiKH;
            update.TenDN = model.TenDN;
            update.Matkhau = model.Matkhau;
            update.Ngaysinh = model.Ngaysinh;
            update.Gioitinh = model.Gioitinh;
            update.Email = model.Email;

            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        public ActionResult Delete(int id)
        {
            BANSACHEntities db = new BANSACHEntities();
            // tìm đối tượng
            var update = db.KHACHHANGs.Find(id);
            // lệnh xóa
            db.KHACHHANGs.Remove(update);
            //lưu
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
    }
}