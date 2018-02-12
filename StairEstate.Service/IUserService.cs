using StairEstate.Entity;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public interface IUserService: IService<sys_user>
    {
        sys_user ValidateUser(sys_user user);

        bool AuthorizedUser(string url);
    }
}