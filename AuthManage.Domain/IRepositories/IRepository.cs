﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Domain.IRepositories
{
    //定义通用仓储接口
    public interface IRepository<TEntity>
    {
        void AddEntity(TEntity entity);

        void DeleteEntity(TEntity entity);

        void DeleteEntityById(int id);

        void UpdateEntity(TEntity entity);

        List<TEntity> GetAllEntities();
    }
}