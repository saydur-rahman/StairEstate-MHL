namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sales_collector
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sales_collector()
        {
            sales_customer = new HashSet<sales_customer>();
        }

        [Key]
        public int collector_id { get; set; }

        [StringLength(50)]
        public string collector_code { get; set; }

        [StringLength(50)]
        public string collector_phone { get; set; }

        [StringLength(50)]
        public string collector_father_or_husband_name { get; set; }

        [StringLength(50)]
        public string collector_mother_name { get; set; }

        [StringLength(50)]
        public string collector_parmanent_address { get; set; }

        [StringLength(50)]
        public string collector_present_address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? collector_dob { get; set; }

        [StringLength(50)]
        public string collector_birth_place { get; set; }

        [StringLength(50)]
        public string collector_name { get; set; }

        public int? collector_profession_id { get; set; }

        public int? collector_branch_id { get; set; }

        public int? collector_sales_person_id { get; set; }

        [StringLength(200)]
        public string collector_image { get; set; }

        public bool? deleted { get; set; }

        public virtual hr_employee hr_employee { get; set; }

        public virtual hr_profession hr_profession { get; set; }

        public virtual sys_branch sys_branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_customer> sales_customer { get; set; }
    }
}
