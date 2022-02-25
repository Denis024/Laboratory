//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laboratory.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.BloodServices = new HashSet<BloodService>();
        }
    
        public int ID { get; set; }
        public int PatientsID { get; set; }
        public int UsersID { get; set; }
        public int ServicesCode { get; set; }
        public string Barcode { get; set; }
        public System.DateTime Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BloodService> BloodServices { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}