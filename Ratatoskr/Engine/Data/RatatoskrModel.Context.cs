﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Engine.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RatatoskrContext : DbContext
    {
        public RatatoskrContext()
            : base("name=RatatoskrContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Tbl_Account> Tbl_Account { get; set; }
        public virtual DbSet<Tbl_Armor> Tbl_Armor { get; set; }
        public virtual DbSet<Tbl_Consumable> Tbl_Consumable { get; set; }
        public virtual DbSet<Tbl_ConsumableType> Tbl_ConsumableType { get; set; }
        public virtual DbSet<Tbl_Creature> Tbl_Creature { get; set; }
        public virtual DbSet<Tbl_EquipmentSlot> Tbl_EquipmentSlot { get; set; }
        public virtual DbSet<Tbl_Item> Tbl_Item { get; set; }
        public virtual DbSet<Tbl_ItemType> Tbl_ItemType { get; set; }
        public virtual DbSet<Tbl_Weapon> Tbl_Weapon { get; set; }
    }
}