using AuthManage.Application.DTOModel.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.IAppServices
{
    public interface IRecordAppService
    {
        //根据ItemBaseOnHardware获取记录（根据外键获取记录）
        List<RecordDto> GetDtosByItemBaseOnHardwareID(int id);
    }
}
