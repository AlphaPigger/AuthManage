using AuthManage.Domain;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthManage.Infrastructure.Repositories
{
    public class Repository<TEntity> :IRepository<TEntity> where TEntity:class
    {
        /**数据库上下文获取**/
        //通过依赖注入获取
        private DataContext _dataContext;
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /**实现接口下的方法**/
        public void AddEntity(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
            Save();
        }

        public void DeleteEntity(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
            Save();
        }

        public void DeleteEntityById(int id)
        {
            _dataContext.Set<TEntity>().Remove(GetEntity(id));
            Save();
        }

        public void UpdateEntity(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
            Save();
        }

        public List<TEntity> GetAllEntities()
        {
            return _dataContext.Set<TEntity>().ToList();
        }

        /**事务性保存**/
        private void Save()
        {
            _dataContext.SaveChanges();
        }
        //根据id获取实体
        private TEntity GetEntity(int id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }
    }
}
