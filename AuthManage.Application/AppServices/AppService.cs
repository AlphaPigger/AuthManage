using AuthManage.Application.IAppServices;
using AuthManage.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class AppService<TDto>:IAppService<TDto>
    {
        //实现接口下的方法
        public void AddDto(TDto dto)
        {

        }

        public void DeleteDto(TDto dto)
        {

        }

        public void DeleteDtoById(int id)
        {

        }

        public void UpdateDto(TDto dto)
        {

        }

        public List<TDto> GetAllDtos()
        {
            return new List<TDto>();
        }

    }
}
