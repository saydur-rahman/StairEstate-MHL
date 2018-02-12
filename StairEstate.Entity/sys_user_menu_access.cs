namespace StairEstate.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class sys_user_menu_access
    {
        [Key]
        public int sys_menu_access_id { get; set; }

        public int? menu_id { get; set; }

        public int? usr_type_id { get; set; }

        public virtual sys_user_type sys_user_type { get; set; }
    }
}
