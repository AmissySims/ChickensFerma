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
    
    public partial class OrderEggs
    {
        public int Id { get; set; }
        public Nullable<int> OrderId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<int> TypeStandartId { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual TypeStandart TypeStandart { get; set; }
    }
}
