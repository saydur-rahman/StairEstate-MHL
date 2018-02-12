namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class survey_master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public survey_master()
        {
            survey_answer = new HashSet<survey_answer>();
        }

        public long id { get; set; }

        public int? branch { get; set; }

        public DateTime? surveytime { get; set; }

        public int? userid { get; set; }

        public long? agenda { get; set; }

        public bool? deleted { get; set; }

        public virtual survey_agenda survey_agenda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<survey_answer> survey_answer { get; set; }

        public virtual sys_branch sys_branch { get; set; }

        public virtual sys_user sys_user { get; set; }
    }
}
