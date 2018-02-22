namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_menu
    {
        [Key]
        public int menu_id { get; set; }

        [StringLength(50)]
        public string menu_name { get; set; }

        public int? menu_type { get; set; }

        [StringLength(50)]
        public string menu_link { get; set; }

        [StringLength(50)]
        public string menu_parent { get; set; }

        public int? menu_presidence { get; set; }
    }
}
