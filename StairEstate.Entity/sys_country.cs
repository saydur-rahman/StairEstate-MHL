namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sys_country()
        {
            sys_branch = new HashSet<sys_branch>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? currency { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sys_branch> sys_branch { get; set; }

        public virtual sys_currency sys_currency { get; set; }
    }
}
