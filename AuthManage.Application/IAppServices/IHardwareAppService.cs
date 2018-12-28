using AuthManage.Application.DTOModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IHardwareAppService
    {
        void AddDto(HardwareDto hardwareDto);
        void DeleteDto(HardwareDto hardwareDto);
        void DeleteDtoByID(int id);
        void UpdateDto(HardwareDto hardwareDto);
        HardwareDto GetDtoByID(int id);
        List<HardwareDto> GetHardwareDtos();
    }
}
