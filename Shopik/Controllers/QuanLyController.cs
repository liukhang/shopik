using Shopik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace Shopik.Controllers
{
    public class QuanLyController : Controller
    {
        // GET: QuanLy
        ShopikEntities db = new ShopikEntities();
        public ActionResult Index()
        {
            return View(db.ChuDes.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(int id, string ChuDeName)
        {
            ChuDe sp = new ChuDe();
            sp.id = id;
            sp.ChuDeName = ChuDeName;
            db.ChuDes.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult XoaChuDe(int id)
        {
            //Lấy ra đối tượng theo mã 
            ChuDe a = db.ChuDes.SingleOrDefault(n => n.id == id);
            if (a == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(a);
        }
        [HttpPost, ActionName("XoaChuDe")]

        public ActionResult XacNhanXoaChuDe(int id)
        {
            ChuDe a = db.ChuDes.SingleOrDefault(n => n.id == id);
            if (a == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //List cate
        public ActionResult Cate()
        {
            return View(db.Cates.ToList());
        }
        // Add Cate
        [HttpGet]
        public ActionResult CreateCate()
        {
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateCate(int id, string CateName, int ChuDe_id)
        {
            Cate b = new Cate();
            b.id = id;
            b.CateName = CateName;
            b.ChuDe_id = ChuDe_id;
            db.Cates.Add(b);
            db.SaveChanges();
            return RedirectToAction("Cate");
        }

        // Edit Cate
        [HttpGet]
        public ActionResult EditCate(int id)
        {
            //Lấy ra đối tượng sách theo mã 
            Cate cate = db.Cates.SingleOrDefault(n => n.id == id);
            if (cate == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName", cate.ChuDe_id);
            return View(cate);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditCate(Cate cate)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName", cate.ChuDe_id);

            return RedirectToAction("Cate");
        }
        // Delete Cate
        [HttpGet]
        public ActionResult XoaCate(int id)
        {
            //Lấy ra đối tượng theo mã 
            Cate a = db.Cates.SingleOrDefault(n => n.id == id);
            if (a == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(a);
        }
        [HttpPost, ActionName("XoaCate")]

        public ActionResult XacNhanXoaCate(int id)
        {
            Cate a = db.Cates.SingleOrDefault(n => n.id == id);
            if (a == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Cates.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Cate");
        }
        // List product
        public ActionResult Product(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.Products.ToList().OrderBy(n => n.id).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            //Đưa dữ liệu vào dropdownlist
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName");
            ViewBag.Cate_id = new SelectList(db.Cates.ToList().OrderBy(n => n.CateName), "id", "CateName");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase fileUpload)
        {
            //Đưa dữ liệu vào dropdownlist
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName");
            ViewBag.Cate_id = new SelectList(db.Cates.ToList().OrderBy(n => n.CateName), "id", "CateName");
            //kiểm tra đường dẫn ảnh bìa
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Lưu tên file
                var fileName = Path.GetFileName(fileUpload.FileName);
                //Lưu đường dẫn của file
                var path = Path.Combine(Server.MapPath("~/HinhAnhSP"), fileName);
                //Kiểm tra hình ảnh đã tồn tại chưa
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileUpload.SaveAs(path);
                }
                product.AnhBia = fileUpload.FileName;
                db.Products.Add(product);
                db.SaveChanges();
            }
            return RedirectToAction("Product");
        }
        // Edit Product
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            //Lấy ra đối tượng  theo mã 
            Product product = db.Products.SingleOrDefault(n => n.id == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName",product.ChuDe_id);
            ViewBag.Cate_id = new SelectList(db.Cates.ToList().OrderBy(n => n.CateName), "id", "CateName",product.Cate_id);
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProduct(Product product, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.ChuDe_id = new SelectList(db.ChuDes.ToList().OrderBy(n => n.ChuDeName), "id", "ChuDeName", product.ChuDe_id);
            ViewBag.Cate_id = new SelectList(db.Cates.ToList().OrderBy(n => n.CateName), "id", "CateName", product.Cate_id);
            return RedirectToAction("Product");
        }
        //Hiển thị sản phẩm
        public ActionResult DetailsProduct(int id)
        {

            //Lấy ra đối tượng sách theo mã 
            Product product = db.Products.SingleOrDefault(n => n.id == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult XoaProduct(int id)
        {
            //Lấy ra đối tượng sách theo mã 
            Product product = db.Products.SingleOrDefault(n => n.id == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(product);
        }
        [HttpPost, ActionName("XoaProduct")]

        public ActionResult XacNhanXoa(int id)
        {
            Product product = db.Products.SingleOrDefault(n => n.id == id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Product");
        }
        //DonHang
        public ActionResult DonHang()
        {
            return View(db.DonHangs.ToList());
        }
        // Xoa Don Hang
        [HttpGet]
        public ActionResult XoaDonHang(int id)
        {
            //Lấy ra đối tượng sách theo mã 
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.id == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donhang);
        }
        [HttpPost, ActionName("XoaDonHang")]

        public ActionResult XacNhanXoaDonHang(int id)
        {
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.id == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DonHangs.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("DonHang");
        }
        //Chi Tiet Don Hang
        public ActionResult ChiTietDonHang()
        {
            return View(db.ChiTietDonHangs.ToList());
        }
        // Xoa Don Hang
        [HttpGet]
        public ActionResult XoaChiTietDonHang(int id)
        {
            //Lấy ra đối tượng sách theo mã 
            ChiTietDonHang donhang = db.ChiTietDonHangs.SingleOrDefault(n => n.id == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(donhang);
        }
        [HttpPost, ActionName("XoaChiTietDonHang")]

        public ActionResult XacNhanXoaChiTietDonHang(int id)
        {
            ChiTietDonHang donhang = db.ChiTietDonHangs.SingleOrDefault(n => n.id == id);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChiTietDonHangs.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("ChiTietDonHang");
        }
    }
}