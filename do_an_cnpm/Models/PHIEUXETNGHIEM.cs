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
    
    public partial class PHIEUXETNGHIEM
    {
        public int MaPXN { get; set; }
        public Nullable<int> MaBN { get; set; }
        public Nullable<int> MaBacSi { get; set; }
        public string ChuanDoan { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public string YeuCauXetNghiem { get; set; }
        public string KetQuaXetNghiem { get; set; }
    
        public virtual BACSI BACSI { get; set; }
        public virtual BENHNHAN BENHNHAN { get; set; }
    }
}