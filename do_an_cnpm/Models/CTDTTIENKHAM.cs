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
    
    public partial class CTDTTIENKHAM
    {
        public int STT { get; set; }
        public System.DateTime Ngay { get; set; }
        public Nullable<int> MaDTTK { get; set; }
        public Nullable<int> TienKham { get; set; }
        public Nullable<int> TienDichVu { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual DOANHTHUTIENKHAM DOANHTHUTIENKHAM { get; set; }
    }
}