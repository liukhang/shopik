using Shopik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopik.Controllers
{
    public class ProductController : Controller
    {
        ShopikEntities db = new ShopikEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult XemChiTiet(int id = 0)
        {
            Product product = db.Products.SingleOrDefault(n => n.id == id);
            if (product == null)
            {
                //Trả về trang báo lỗi 
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.ChuDeName = db.ChuDes.Single(n => n.id == product.ChuDe_id).ChuDeName;
            ViewBag.CateName = db.Cates.Single(n => n.id == product.Cate_id).CateName;
            return View(product);
        }
    }
}