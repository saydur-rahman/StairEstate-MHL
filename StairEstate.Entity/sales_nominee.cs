namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_nominee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int nominee_id { get; set; }

        public int? nominee_customer_id { get; set; }

        public int? nominee_position_id { get; set; }

        [StringLength(50)]
        public string nominee_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? nominee_dob { get; set; }

        [StringLength(50)]
        public string nominee_identification_no { get; set; }

        [StringLength(50)]
        public string nominee_relation { get; set; }

        [StringLength(200)]
        public string nominee_details { get; set; }

        public double? nominee_share { get; set; }

        [StringLength(200)]
        public string nominee_image { get; set; }

        public bool? deleted { get; set; }

        public virtual sales_customer sales_customer { get; set; }

        public virtual sales_nominee_type sales_nominee_type { get; set; }
    }
}
