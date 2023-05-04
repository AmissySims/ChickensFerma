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
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderChicken = new HashSet<OrderChicken>();
            this.OrderEggs = new HashSet<OrderEggs>();
        }
    
        public int Id { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> TypeProdId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> StatusId { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Status Status { get; set; }
        public virtual TypeProd TypeProd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderChicken> OrderChicken { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEggs> OrderEggs { get; set; }
    }
}
