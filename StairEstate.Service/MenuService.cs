using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StairEstate.Entity;
using StairEstate.Repo.Generics;
using StairEstate.Repo.Interfaces;
using StairEstate.Service.Generics;

namespace StairEstate.Service
{
    public class MenuService : Service<sys_menu>, IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        
        public MenuService(IMenuRepository menuRepository, IRepository<sys_menu> repository) : base(repository)
        {
            _menuRepository = menuRepository;
        }
    

        //public void Create(sys_menu entity)
        //{
        //    _menuRepository.Add(entity);
        //}

        //public void CreateMany(IEnumerable<sys_menu> entities)
        //{
        //    _menuRepository.AddRange(entities);
        //}

        //public void Delete(int? id)
        //{
        //    _menuRepository.Remove(id);
        //}

        //public void Delete(sys_menu entity)
        //{
        //    _menuRepository.Remove(entity);
        //}

        //public void DeleteMany(IEnumerable<sys_menu> entities)
        //{
        //    _menuRepository.RemoveRange(entities);
        //}

        //public void Edit(sys_menu entity)
        //{
        //    _menuRepository.Update(entity);
        //}

        //public IEnumerable<sys_menu> FindWithWhere(Expression<Func<sys_menu, bool>> predicate)
        //{
        //    return _menuRepository.Find(predicate);
        //}

        //public IEnumerable<sys_menu> GetAll()
        //{
        //    return _menuRepository.GetAll();
        //}

        //public sys_menu GetById(int? id)
        //{
        //    return _menuRepository.Get(id);
        //}

        public IEnumerable<sys_menu> GetSysMenus()
        {
            if (UserSession.GetUserFromSession() != null)
                return _menuRepository.GetMenusForCurrentUser(UserSession.GetUserFromSession().user_id);

            return null;
        }
    }
}
