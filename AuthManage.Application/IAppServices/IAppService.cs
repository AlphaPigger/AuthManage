using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IAppService<TDto>
    {
        void AddDto(TDto dto);
        void DeleteDto(TDto dto);
        void DeleteDtoById(int id);
        void UpdateDto(TDto dto);
        List<TDto> GetAllDtos();
    }
}
