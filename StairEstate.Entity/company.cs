namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("company")]
    public partial class company
    {
        public int id { get; set; }

        [StringLength(100)]
        public string companyname { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(100)]
        public string TIN { get; set; }

        [StringLength(50)]
        public string BIN { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string started { get; set; }
    }
}
