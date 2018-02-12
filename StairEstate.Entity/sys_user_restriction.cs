namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_user_restriction
    {
        public int id { get; set; }

        public int? userid { get; set; }

        public int? accesscode { get; set; }

        public virtual sys_restrictions sys_restrictions { get; set; }

        public virtual sys_user sys_user { get; set; }
    }
}
