namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("lisence")]
    public partial class lisence
    {
        public int id { get; set; }

        [StringLength(1000)]
        public string code { get; set; }

        [StringLength(50)]
        public string expires { get; set; }
    }
}
