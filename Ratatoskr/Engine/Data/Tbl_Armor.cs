//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Tbl_Armor
    {
        public int ItemID { get; set; }
        public string EquipmentSlot { get; set; }
        public int ArmorRating { get; set; }
    
        public virtual Tbl_EquipmentSlot Tbl_EquipmentSlot { get; set; }
        public virtual Tbl_Item Tbl_Item { get; set; }
    }
}
