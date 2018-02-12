namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_loginlog
    {
        public long id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? logindate { get; set; }

        [StringLength(50)]
        public string logintime { get; set; }

        [StringLength(50)]
        public string loginuser { get; set; }
    }
}
