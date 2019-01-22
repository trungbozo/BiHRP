namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Toolbar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Toolbar()
        {
            SYS_Toolbar1 = new HashSet<SYS_Toolbar>();
        }

        [Key]
        public int ID_SYS_Toolbar { get; set; }

        [Required]
        [StringLength(50)]
        public string ToolbarType { get; set; }

        [Required]
        [StringLength(150)]
        public string ToolbarText { get; set; }

        [Required]
        [StringLength(50)]
        public string ToolbarImage { get; set; }

        [Required]
        [StringLength(50)]
        public string ToolbarDisImage { get; set; }

        [StringLength(50)]
        public string ToolbarAction { get; set; }

        public int? ID_Form { get; set; }

        public int? ID_SYS_Toolbar_Parent { get; set; }

        [StringLength(10)]
        public string OrderBy { get; set; }

        [StringLength(50)]
        public string ToolbarName { get; set; }

        public bool? DisableItem { get; set; }

        public bool? EnableItem { get; set; }

        [StringLength(50)]
        public string Language { get; set; }

        public int? ID_Action { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Toolbar> SYS_Toolbar1 { get; set; }

        public virtual SYS_Toolbar SYS_Toolbar2 { get; set; }
    }
}
