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
    
    public partial class ServicesUser
    {
        public int ID { get; set; }
        public int UsersID { get; set; }
        public int ServicesCode { get; set; }
    
        public virtual Service Service { get; set; }
        public virtual User User { get; set; }
    }
}
