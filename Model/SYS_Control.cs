namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Control
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SYS_Control()
        {
            SYS_Control1 = new HashSet<SYS_Control>();
        }

        [Key]
        public int ID_SYS_Control { get; set; }

        public int ID_Form { get; set; }

        [Required]
        [StringLength(250)]
        public string LabelControl { get; set; }

        [Required]
        [StringLength(250)]
        public string NameControl { get; set; }

        [StringLength(250)]
        public string TypeControl { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [StringLength(10)]
        public string OrderBy { get; set; }

        public int? ID_SYS_Control_Parent { get; set; }

        public int? WidthControl { get; set; }

        [StringLength(100)]
        public string ApiName { get; set; }

        [StringLength(500)]
        public string DisplayText { get; set; }

        [StringLength(50)]
        public string ValueText { get; set; }

        [StringLength(50)]
        public string ValueChild { get; set; }

        public bool? ValueDisable { get; set; }

        public bool? ValueRequired { get; set; }

        [StringLength(50)]
        public string ValueValidate { get; set; }

        [StringLength(50)]
        public string ValueDateFormat { get; set; }

        [StringLength(50)]
        public string ValueServerDateFormat { get; set; }

        [StringLength(50)]
        public string ValueNumberFormat { get; set; }

        public int? ValueMaxLength { get; set; }

        public int? HeightControl { get; set; }

        public int? ID_Action { get; set; }

        [StringLength(250)]
        public string XML_Link { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SYS_Control> SYS_Control1 { get; set; }

        public virtual SYS_Control SYS_Control2 { get; set; }
    }
}
