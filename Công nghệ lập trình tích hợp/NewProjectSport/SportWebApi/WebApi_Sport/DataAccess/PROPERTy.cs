namespace WebApi_Sport.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROPERTIES")]
    public partial class PROPERTy
    {
        [Key]
        public int PropertiesID { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string Size { get; set; }

        [StringLength(255)]
        public string DetailDescription { get; set; }

        public int? ProductID { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
