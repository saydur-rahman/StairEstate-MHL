namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_scheduler
    {
        public long id { get; set; }

        public DateTime? rundatetime { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(100)]
        public string detail { get; set; }

        public bool? didran { get; set; }
    }
}
