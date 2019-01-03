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
            List<RecordDto> recordDtos = new List<RecordDto>();
            var records = _recordRepository.GetRecordsByItemBaseOnHardwareID(id);
            foreach (var record in records)
            {
                RecordDto recordDto = new RecordDto();
                recordDto.ID = record.ID;
                recordDto.UpdateTime = record.UpdateTime;
                recordDto.UpdateUser = record.UpdateUser;
                recordDto.Remark = record.Remark;
                if (record.Status == 0)
                {
                    recordDto.Status = "未测试";
                }
                else if (record.Status == 1)
                {
                    recordDto.Status = "正常";
                }
                else if (record.Status==2)
                {
                    recordDto.Status = "异常";
                }
                recordDtos.Add(recordDto);
            }
            return recordDtos;
        }
    }
}
