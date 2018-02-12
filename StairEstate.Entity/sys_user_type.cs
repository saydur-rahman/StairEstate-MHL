using System.ComponentModel;

namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_user_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_user_type()
        {
            sys_user = new HashSet<sys_user>();
            sys_user_menu_access = new HashSet<sys_user_menu_access>();
        }

        [Key]
        public int usr_type_Id { get; set; }

        [StringLength(50)]
        [DisplayName("Typename")]
        public string type_name { get; set; }

        [StringLength(50)]
        [DisplayName("Description")]
        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_user> sys_user { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_user_menu_access> sys_user_menu_access { get; set; }
    }
}
