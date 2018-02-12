namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class survey_answer
    {
        public long id { get; set; }

        public long? question { get; set; }

        [StringLength(50)]
        public string answer { get; set; }

        [StringLength(200)]
        public string detail { get; set; }

        public long? survey { get; set; }

        public virtual survey_master survey_master { get; set; }

        public virtual survey_question survey_question { get; set; }
    }
}
