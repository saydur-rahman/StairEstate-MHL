namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class hr_profession
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hr_profession()
        {
            sales_collector = new HashSet<sales_collector>();
            sales_customer = new HashSet<sales_customer>();
        }

        [Key]
        public int profession_id { get; set; }

        [StringLength(50)]
        public string profession_name { get; set; }

        public int? profession_presidences { get; set; }

        public bool? deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_collector> sales_collector { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_customer> sales_customer { get; set; }
    }
}
