namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_branch()
        {
            hr_employee = new HashSet<hr_employee>();
            sales_collector = new HashSet<sales_collector>();
            survey_master = new HashSet<survey_master>();
            sys_user = new HashSet<sys_user>();
        }

        [Key]
        public int branch_id { get; set; }

        [StringLength(50)]
        public string branch_name { get; set; }

        [StringLength(300)]
        public string branch_address { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string branch_tin { get; set; }

        public int? country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hr_employee> hr_employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_collector> sales_collector { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<survey_master> survey_master { get; set; }

        public virtual sys_country sys_country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_user> sys_user { get; set; }
    }
}
