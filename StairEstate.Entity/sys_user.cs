namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_user()
        {
            survey_master = new HashSet<survey_master>();
            sys_user_restriction = new HashSet<sys_user_restriction>();
        }

        [Key]
        public int user_id { get; set; }

        [StringLength(50)]
        public string user_name { get; set; }

        [StringLength(50)]
        public string user_password { get; set; }

        [StringLength(50)]
        public string user_email { get; set; }

        [StringLength(50)]
        public string user_phone { get; set; }

        [StringLength(50)]
        public string user_address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? user_creation { get; set; }

        [StringLength(100)]
        public string full_name { get; set; }


        [ForeignKey("sys_user_type")]
        public int? usr_type_id { get; set; }


        [ForeignKey("sys_branch")]
        public int? branch_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<survey_master> survey_master { get; set; }

        public virtual sys_branch sys_branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_user_restriction> sys_user_restriction { get; set; }

        public virtual sys_user_type sys_user_type { get; set; }
    }
}
