//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Admin.ComponentsAdmin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cage()
        {
            this.Chicken = new HashSet<Chicken>();
        }
    
        public int Id { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<bool> IsPaus { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Size Size { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chicken> Chicken { get; set; }
    }
}
