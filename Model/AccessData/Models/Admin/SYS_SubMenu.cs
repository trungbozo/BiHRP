//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.AccessData.Models.Admin
{
    using System;
    using System.Collections.Generic;
    
    public partial class SYS_SubMenu
    {
        public int id { get; set; }
        public int ID_SYS_Menu { get; set; }
        public string ControllerName { get; set; }
        public string ActionMethod { get; set; }
        public string SubMenuName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public bool Status { get; set; }
    }
}