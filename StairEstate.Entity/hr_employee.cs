namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class hr_employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hr_employee()
        {
            sales_collector = new HashSet<sales_collector>();
            sales_customer = new HashSet<sales_customer>();
        }

        [Key]
        public int emp_id { get; set; }

        [StringLength(50)]
        public string emp_code { get; set; }

        [StringLength(50)]
        public string emp_name { get; set; }

        [StringLength(50)]
        public string emp_email { get; set; }

        [StringLength(50)]
        public string emp_phone { get; set; }

        [StringLength(50)]
        public string emp_father_or_husband_name { get; set; }

        [StringLength(50)]
        public string emp_mother_name { get; set; }

        [StringLength(50)]
        public string emp_permanent_address { get; set; }

        [StringLength(50)]
        public string emp_present_address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? emp_dob { get; set; }

        [StringLength(50)]
        public string emp_birth_place { get; set; }

        public int? emp_type_id { get; set; }

        public int? emp_branch_id { get; set; }

        [StringLength(200)]
        public string emp_image { get; set; }

        public bool? deleted { get; set; }

        public virtual hr_employee_type hr_employee_type { get; set; }

        public virtual sys_branch sys_branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_collector> sales_collector { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_customer> sales_customer { get; set; }
    }
}
