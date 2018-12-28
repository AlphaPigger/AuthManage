using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class RecordAppService:IRecordAppService
    {
        //依赖注入
        private IRecordRepository _recordRepository;
        public RecordAppService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }

        public List<RecordDto> GetDtosByItemBaseOnHardwareID(int id)
        {
            return Mapper.Map<List<RecordDto>>(_recordRepository.GetRecordsByItemBaseOnHardwareID(id));
        }
    }
}
