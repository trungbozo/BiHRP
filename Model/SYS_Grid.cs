namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Grid
    {
        [Key]
        public int ID_SYS_Grid { get; set; }

        public int ID_Form { get; set; }

        [Required]
        [StringLength(50)]
        public string NameColumn { get; set; }

        [Required]
        [StringLength(50)]
        public string MemberColumn { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeColumn { get; set; }

        [Required]
        [StringLength(50)]
        public string WidthColumn { get; set; }

        [StringLength(50)]
        public string AlignHeader { get; set; }

        [StringLength(50)]
        public string AlignColumn { get; set; }

        [StringLength(10)]
        public string OrderBy { get; set; }

        [StringLength(100)]
        public string ApiName { get; set; }
    }
}
