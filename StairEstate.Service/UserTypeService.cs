using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class UserTypeService: Service<sys_user_type>, IUserTypeService
    {
        public UserTypeService(IRepository<sys_user_type> repository) : base(repository)
        {
        }
    }
}
