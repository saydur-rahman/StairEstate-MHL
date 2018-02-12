namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class survey_user_access
    {
        public int id { get; set; }

        public int? userid { get; set; }

        public int? agenda { get; set; }

        public int? total { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expiredate { get; set; }
    }
}
