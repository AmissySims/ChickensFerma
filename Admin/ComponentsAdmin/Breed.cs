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
    
    public partial class Breed
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Breed()
        {
            this.Chicken = new HashSet<Chicken>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string AverageWeight { get; set; }
        public string AveragePerformance { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Chicken> Chicken { get; set; }
    }
}
