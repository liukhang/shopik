using Shopik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopik.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        ShopikEntities db = new ShopikEntities();
        public ActionResult ChuDePartial()
        {
            ViewBag.men = db.ChuDes.SingleOrDefault(n => n.id == 1).ChuDeName;
            ViewBag.women = db.ChuDes.SingleOrDefault(n => n.id == 2).ChuDeName;
            ViewBag.catewomen = db.Cates.Where(n => n.ChuDe_id == 2).OrderBy(n => n.CateName).ToList();
            ViewBag.catemen = db.Cates.Where(n => n.ChuDe_id == 1).OrderBy(n => n.CateName).ToList();
            return PartialView();
        }
        public ViewResult ProductTheoChuDe(int id = 0)
        {
            //Kiểm tra chủ đề tồn tại hay không
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.id == id);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuất danh sách các product theo chủ đề
            List<Product> lstProduct = db.Products.Where(n => n.ChuDe_id == id).OrderBy(n => n.Price).ToList();
            if (lstProduct.Count == 0)
            {
                ViewBag.Product = "Không có sp nào thuộc chủ đề này";
            }
            //Gán danh product chủ để
            ViewBag.lstChuDe = db.ChuDes.ToList();
            ViewBag.ChuDeName = cd.ChuDeName.ToString();
            return View(lstProduct);
        }
        public ViewResult Women()
        {
            //Lấy ra chủ đề đầu tiên trong csdl
            int id = int.Parse(db.ChuDes.ToList().ElementAt(0).id.ToString());
            //Tạo 1 viewbag gán product theo chủ đề đầu tiên trong csdl
            ViewBag.ProductTheoChuDe2 = db.Products.Where(n => n.ChuDe_id == 2).ToList();
            return View(db.ChuDes.ToList());
        }
        public ViewResult Men()
        {
            //Lấy ra chủ đề đầu tiên trong csdl
            int id = int.Parse(db.ChuDes.ToList().ElementAt(0).id.ToString());
            //Tạo 1 viewbag gán product theo chủ đề đầu tiên trong csdl
            ViewBag.ProductTheoChuDe1 = db.Products.Where(n => n.ChuDe_id == 1).ToList();
            return View(db.ChuDes.ToList());
        }
    }
}