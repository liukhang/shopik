using Shopik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;

namespace Shopik.Controllers
{
    public class CateController : Controller
    {
        ShopikEntities db = new ShopikEntities();
        // GET: Cate
        public ViewResult ProductTheoCate(int id = 0)
        {
            //Kiểm tra chủ đề tồn tại hay không
            Cate cd = db.Cates.SingleOrDefault(n => n.id == id);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuất danh sách các product theo chủ đề
            List<Product> lstProduct = db.Products.Where(n => n.Cate_id == id).OrderBy(n => n.Price).ToList();
            if (lstProduct.Count == 0)
            {
                ViewBag.Product = "Không có sp nào thuộc chủ đề này";
            }
            //Gán danh product chủ để
            ViewBag.lstCate = db.Cates.ToList();
            ViewBag.CateName = cd.CateName.ToString();
            return View(lstProduct);
        }
        public ViewResult DanhMucCate(int? page)
        {
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            //Lấy ra chủ đề đầu tiên trong csdl
            int id = int.Parse(db.Cates.ToList().ElementAt(0).id.ToString());
            //Tạo 1 viewbag gán product theo chủ đề đầu tiên trong csdl
            ViewBag.ProductTheoCate = db.Products.OrderBy(n => n.id).ToPagedList(pageNumber, pageSize);
            return View(db.Cates.ToList());
        }
    }
}