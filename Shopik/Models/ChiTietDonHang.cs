//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopik.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietDonHang
    {
        public int id { get; set; }
        public Nullable<int> Product_id { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<decimal> DonGia { get; set; }
        public Nullable<int> DonHang_id { get; set; }
    
        public virtual DonHang DonHang { get; set; }
        public virtual Product Product { get; set; }
    }
}