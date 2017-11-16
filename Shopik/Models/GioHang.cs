using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shopik.Models
{
    public class GioHang
    {
        ShopikEntities db = new ShopikEntities();
        public int id { get; set; }
        public string ProductName { get; set; }
        public string AnhBia { get; set; }
        public double Price { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien
        {
            get { return SoLuong * Price; }
        }
        public GioHang(int idp)
        {
            id = idp;
            Product product = db.Products.Single(n => n.id == idp);
            
            ProductName = product.ProductName;
            AnhBia = product.AnhBia;
            Price = double.Parse(product.Price.ToString());
            SoLuong = 1;
        }
    }
}