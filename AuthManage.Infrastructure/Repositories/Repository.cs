using AuthManage.Domain;
using AuthManage.Domain.IRepositories;
using AuthManage.MVC;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity>
    {
        /**数据库上下文获取**/
        private DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /**实现接口下的方法**/
        public void AddEntity(TEntity entity)
        {

        }

        public void DeleteEntity(TEntity entity)
        {

        }

        public void DeleteEntityById(int id)
        {

        }

        public void UpdateEntity(TEntity entity)
        {

        }

        public List<TEntity> GetAllEntities()
        {
            return new List<TEntity>();
        }

        /**事务性保存**/
        public void Save()
        {
            _dataContext.SaveChanges();
        }
    }
}
