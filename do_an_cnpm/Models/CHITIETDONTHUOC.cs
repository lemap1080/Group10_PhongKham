//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace do_an_cnpm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIETDONTHUOC
    {
        public int MaCTDT { get; set; }
        public Nullable<int> MaDonThuoc { get; set; }
        public Nullable<int> MaThuoc { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string CachDung { get; set; }
        public Nullable<int> DonGiaBan { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual DONTHUOC DONTHUOC { get; set; }
        public virtual THUOC THUOC { get; set; }
    }
}
