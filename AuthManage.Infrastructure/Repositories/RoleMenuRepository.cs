using AuthManage.Domain.IRepositories;
using AuthManage.Domain.RelationModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Infrastructure.Repositories
{
    public class RoleMenuRepository:Repository<RoleMenu>,IRoleMenuRepository
    {
        //依赖注入
        private DataContext _dataContext;
        //构造函数
        public RoleMenuRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
        //根据RoleID获取功能集合
        public List<int> GetAllMenuIDByRoleID(int RoleID)
        {
            List<int> allMenuID = new List<int>();
            var tems = from r in _dataContext.Set<RoleMenu>() where r.RoleID==RoleID select r;//需要引入LINQ查询命名空间
            foreach(var tem in tems)
            {
                allMenuID.Add(tem.MenuID);
            }
            return allMenuID;
        }
        //更新角色功能关系
        public bool UpdateRoleMenu(int roleId,List<RoleMenu> roleMenus)
        {
            var oldDatas = _dataContext.Set<RoleMenu>().Where(it => it.RoleID == roleId).ToList();
            oldDatas.ForEach(it => _dataContext.Set<RoleMenu>().Remove(it));
            _dataContext.SaveChanges();
            _dataContext.Set<RoleMenu>().AddRange(roleMenus);
            _dataContext.SaveChanges();
            return true;
        }
        //根据角色获取功能
        public List<RoleMenu> GetMenusByRole(int roleID)
        {
            List<RoleMenu> roleMenus = new List<RoleMenu>();
            var tems = from r in _dataContext.Set<RoleMenu>() where r.RoleID == roleID select r;
            foreach(var tem in tems)
            {
                roleMenus.Add(tem);
            }
            return roleMenus;
        }
    }
}
