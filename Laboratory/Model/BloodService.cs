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
    
    public partial class BloodService
    {
        public int ID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ServicesCode { get; set; }
        public Nullable<System.DateTime> Finished { get; set; }
        public string Starus { get; set; }
        public string Analyzer { get; set; }
        public Nullable<int> UsersID { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
