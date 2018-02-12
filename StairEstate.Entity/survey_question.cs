namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class survey_question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public survey_question()
        {
            survey_answer = new HashSet<survey_answer>();
        }

        public long id { get; set; }

        [StringLength(100)]
        public string question { get; set; }

        [StringLength(50)]
        public string type { get; set; }

        public bool? isdetail { get; set; }

        public int? htmlstring { get; set; }

        public long? agenda { get; set; }

        public virtual survey_agenda survey_agenda { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<survey_answer> survey_answer { get; set; }

        public virtual survey_html survey_html { get; set; }
    }
}
