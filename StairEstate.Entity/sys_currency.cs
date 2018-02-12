namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_currency
    {
        public int id { get; set; }

        [StringLength(50)]
        public string currency_name { get; set; }

        public double? rate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? rate_date { get; set; }

        public bool? isbase { get; set; }

        [StringLength(50)]
        public string shortname { get; set; }

        [StringLength(10)]
        public string symbol { get; set; }

        public virtual sys_country sys_country { get; set; }
    }
}
