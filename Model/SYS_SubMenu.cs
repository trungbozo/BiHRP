namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_SubMenu
    {
        public int id { get; set; }

        public int ID_SYS_Menu { get; set; }

        [Required]
        [StringLength(100)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionMethod { get; set; }

        [Required]
        [StringLength(100)]
        public string SubMenuName { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CreateBy { get; set; }

        public bool Status { get; set; }
    }
}
