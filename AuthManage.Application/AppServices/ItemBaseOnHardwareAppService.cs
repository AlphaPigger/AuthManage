using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using AuthManage.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AuthManage.Application.AppServices
{
    public class ItemBaseOnHardwareAppService : IItemBaseOnHardwareAppService
    {
        //依赖注入
        private IItemBaseOnHardwareRepository _itemBaseOnHardwareRepository;
        private IRecordRepository _recordRepository;
        private DataContext _dataContext;
        public ItemBaseOnHardwareAppService(IItemBaseOnHardwareRepository itemBaseOnHardwareRepository, IRecordRepository recordRepository,DataContext dataContext)
        {
            _itemBaseOnHardwareRepository = itemBaseOnHardwareRepository;
            _recordRepository = recordRepository;
            _dataContext = dataContext;
        }

        public void AddDto(ItemBaseOnHardwareDto dto)
        {

        }
        public void DeleteDto(ItemBaseOnHardwareDto dto)
        {

        }
        public void DeleteDtoById(int id)
        {

        }
        public void UpdateDto(ItemBaseOnHardwareDto dto, string CurrentUser, int HardwareID)
        {
            ItemBaseOnHardware itemBaseOnHardware = new ItemBaseOnHardware();
            itemBaseOnHardware.ID = dto.ID;
            itemBaseOnHardware.Name = dto.Name;
            if (dto.Status == "未测试")
            {
                itemBaseOnHardware.Status = 0;
            }
            else if(dto.Status=="正常")
            {
                itemBaseOnHardware.Status = 1;
            }
            else if (dto.Status == "异常")
            {
                itemBaseOnHardware.Status = 2;
            }
            itemBaseOnHardware.UpdateTime = DateTime.Now.ToString();
            itemBaseOnHardware.UpdateUser = CurrentUser;
            itemBaseOnHardware.Remark = dto.Remark;
            itemBaseOnHardware.HardwareID = HardwareID;
            //判断是否修改
            var tem=_itemBaseOnHardwareRepository.GetEntityByIDNoTrack(dto.ID);//从数据库获取当前修改的对象
            if (tem.Status != itemBaseOnHardware.Status||tem.Remark!=itemBaseOnHardware.Remark)//当界面发生更改，则更新ItemBaseOnHardware表并写入Record表中
            {
                _itemBaseOnHardwareRepository.UpdateEntity(itemBaseOnHardware);//更新到ItemBaseOnHardware表
                Record record = new Record();
                record.Status = itemBaseOnHardware.Status;
                record.UpdateTime = DateTime.Now.ToString();
                record.UpdateUser = CurrentUser;
                record.Remark = dto.Remark;
                record.ItemBaseOnHardwareID = itemBaseOnHardware.ID;//record的外键
                _recordRepository.AddEntity(record);//写入Record表
            }
        }
        public ItemBaseOnHardwareDto GetDtoByID(int id)
        {
            ItemBaseOnHardwareDto itemBaseOnHardwareDto = new ItemBaseOnHardwareDto();
            var itemBaseOnHardwareDomain=_itemBaseOnHardwareRepository.GetEntityByID(id);
            itemBaseOnHardwareDto.ID = itemBaseOnHardwareDomain.ID;
            itemBaseOnHardwareDto.Name = itemBaseOnHardwareDomain.Name;
            if (itemBaseOnHardwareDomain.Status == 0)
            {
                itemBaseOnHardwareDto.Status = "未测试";
            }
            else if(itemBaseOnHardwareDomain.Status==1)
            {
                itemBaseOnHardwareDto.Status = "正常";
            }
            else if (itemBaseOnHardwareDomain.Status == 2)
            {
                itemBaseOnHardwareDto.Status = "异常";
            }
            itemBaseOnHardwareDto.Remark = itemBaseOnHardwareDomain.Remark;
            return itemBaseOnHardwareDto;
        }
        public List<ItemBaseOnHardwareDto> GetAllDtos()
        {
            return null;
        }
        //通过ProjectID获取条目
        public List<ItemBaseOnHardwareDto> GetDtosByHardwareID(int HardwareID)
        {
            List<ItemBaseOnHardwareDto> itemBaseOnHardwareDtos = new List<ItemBaseOnHardwareDto>();
            var tems= _itemBaseOnHardwareRepository.GetItemBaseOnHardwareByHardwareID(HardwareID);
            foreach (var tem in tems)
            {
                ItemBaseOnHardwareDto itemBaseOnHardwareDto = new ItemBaseOnHardwareDto();
                itemBaseOnHardwareDto.ID = tem.ID;
                itemBaseOnHardwareDto.Name = tem.Name;
                if (tem.Status == 0)
                {
                    itemBaseOnHardwareDto.Status = "未测试";
                }
                else if(tem.Status==1)
                {
                    itemBaseOnHardwareDto.Status = "正常";
                }
                else if (tem.Status == 2)
                {
                    itemBaseOnHardwareDto.Status = "异常";
                }
                itemBaseOnHardwareDto.UpdateTime = tem.UpdateTime;
                itemBaseOnHardwareDto.UpdateUser = tem.UpdateUser;
                itemBaseOnHardwareDtos.Add(itemBaseOnHardwareDto);
            }
            return itemBaseOnHardwareDtos;
        }
    }
}
