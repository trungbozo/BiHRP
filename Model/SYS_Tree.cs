namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Tree
    {
        [Key]
        public int ID_SYS_Tree { get; set; }

        public int ID_Form { get; set; }

        [Required]
        [StringLength(100)]
        public string NameTree { get; set; }

        [Required]
        [StringLength(50)]
        public string TextValue { get; set; }

        [Required]
        [StringLength(50)]
        public string IdValue { get; set; }

        [Required]
        [StringLength(50)]
        public string ChildValue { get; set; }

        [StringLength(100)]
        public string ApiName { get; set; }
    }
}
