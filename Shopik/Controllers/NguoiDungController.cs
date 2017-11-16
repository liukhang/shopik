using Shopik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopik.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        ShopikEntities db = new ShopikEntities();
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sEmail = f["txtEmail"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            User kh = db.Users.SingleOrDefault(n => n.Email == sEmail && n.Password == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Xin chao :" + kh.HoTen;
                Session["Username"] = kh;
                Session["HoTen"] = kh.HoTen.ToString();
                return View();
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("DangNhap");
        }
    }
}