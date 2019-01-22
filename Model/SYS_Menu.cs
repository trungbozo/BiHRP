namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Menu()
        {
            SYS_Menu1 = new HashSet<SYS_Menu>();
        }

        [Key]
        public int ID_SYS_Menu { get; set; }

        [Required]
        [StringLength(100)]
        public string ControllerName { get; set; }

        [Required]
        [StringLength(100)]
        public string ActionMethod { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuName { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? CreateBy { get; set; }

        public bool? IsCache { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        public int? ID_SYS_Menu_Parent { get; set; }

        [StringLength(10)]
        public string OrderBy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Menu> SYS_Menu1 { get; set; }

        public virtual SYS_Menu SYS_Menu2 { get; set; }
    }
}
