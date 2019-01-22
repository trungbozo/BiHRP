namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SYS_Form
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_SYS_Form { get; set; }

        [Required]
        [StringLength(500)]
        public string NameForm { get; set; }

        public int? LabelWidth { get; set; }

        public int? InputWidth { get; set; }

        [StringLength(100)]
        public string ApiNameConfig { get; set; }

        [StringLength(100)]
        public string ApiNameControl { get; set; }

        [StringLength(100)]
        public string ApiData { get; set; }

        [StringLength(100)]
        public string ApiNameToolbar { get; set; }

        [StringLength(200)]
        public string ApiListData { get; set; }

        [StringLength(200)]
        public string HelpForm { get; set; }
    }
}
