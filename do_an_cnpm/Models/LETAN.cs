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
    
    public partial class LETAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LETAN()
        {
            this.CAKHAMs = new HashSet<CAKHAM>();
            this.HOADONs = new HashSet<HOADON>();
            this.PHIEUDANGKYKHAMBENHs = new HashSet<PHIEUDANGKYKHAMBENH>();
        }
    
        public int MaLeTan { get; set; }
        public string HoTenLT { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> SDT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAKHAM> CAKHAMs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUDANGKYKHAMBENH> PHIEUDANGKYKHAMBENHs { get; set; }

        public List<LETAN> LTCollection { get; set; }
    }
}
