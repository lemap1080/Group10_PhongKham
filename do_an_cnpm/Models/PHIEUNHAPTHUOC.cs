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
    
    public partial class PHIEUNHAPTHUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAPTHUOC()
        {
            this.CHITIETPHIEUNHAPTHUOCs = new HashSet<CHITIETPHIEUNHAPTHUOC>();
        }
    
        public int MaPNT { get; set; }
        public Nullable<int> MaNCC { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<int> TongTien { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETPHIEUNHAPTHUOC> CHITIETPHIEUNHAPTHUOCs { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}