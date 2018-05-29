using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StairEstate.Entity.View_Model
{
    public class UserTypeVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public UserTypeVM(sys_user_type ut)
        {
            this.Id = ut.usr_type_Id;
            this.Name = ut.type_name;
        }


    }
}
