﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Farmer.Components
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChickensEntities1 : DbContext
    {
        public ChickensEntities1()
            : base("name=ChickensEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Breed> Breed { get; set; }
        public virtual DbSet<Cage> Cage { get; set; }
        public virtual DbSet<Chicken> Chicken { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Eggs> Eggs { get; set; }
        public virtual DbSet<Health> Health { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderChicken> OrderChicken { get; set; }
        public virtual DbSet<OrderEggs> OrderEggs { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<TypeProd> TypeProd { get; set; }
        public virtual DbSet<TypeStandart> TypeStandart { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
