namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sales_customer()
        {
            sales_nominee = new HashSet<sales_nominee>();
        }

        [Key]
        public int customer_id { get; set; }

        [StringLength(50)]
        public string customer_code { get; set; }

        [StringLength(50)]
        public string customer_name { get; set; }

        [StringLength(50)]
        public string customer_phone { get; set; }

        [StringLength(50)]
        public string customer_father_or_husband_name { get; set; }

        [StringLength(50)]
        public string customer_mother_name { get; set; }

        [StringLength(50)]
        public string customer_permanent_address { get; set; }

        [StringLength(50)]
        public string customer_present_address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? customer_dob { get; set; }

        [StringLength(50)]
        public string customer_birth_place { get; set; }

        public int? customer_collector_id { get; set; }

        public int? customer_sales_person_id { get; set; }

        public int? customer_profession_id { get; set; }

        [StringLength(200)]
        public string customer_image { get; set; }

        public bool? deleted { get; set; }

        public virtual hr_employee hr_employee { get; set; }

        public virtual sales_collector sales_collector { get; set; }

        public virtual sales_profession sales_profession { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_nominee> sales_nominee { get; set; }
    }
}
