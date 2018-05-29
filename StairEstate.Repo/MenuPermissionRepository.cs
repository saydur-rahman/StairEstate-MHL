using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Data;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;

namespace StairEstate.Repo
{
    public class UserMenuPermissionRepository: Repository<sys_user_menu_access>, IUserMenuPermissionRepository
    {
        public UserMenuPermissionRepository(MHLDB imhldb) : base(imhldb)
        {
        }
    }
}
