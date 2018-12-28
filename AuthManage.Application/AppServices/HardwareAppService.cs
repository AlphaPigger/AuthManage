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
    public class HardwareAppService:IHardwareAppService
    {
        private IHardwareRepository _hardwareRepository;
        private DataContext _dataContext;
        private IItemBaseOnHardwareRepository _itemBaseOnHardwareRepository;
        public HardwareAppService(IHardwareRepository hardwareRepository,DataContext dataContext,IItemBaseOnHardwareRepository itemBaseOnHardwareRepository)
        {
            _hardwareRepository = hardwareRepository;
            _dataContext = dataContext;
            _itemBaseOnHardwareRepository = itemBaseOnHardwareRepository;
        }

        public void AddDto(HardwareDto hardwareDto)
        {
            Hardware hardwareDomain = new Hardware();
            hardwareDomain.ID = hardwareDto.ID;
            hardwareDomain.Name = hardwareDto.Name;
            hardwareDomain.CreateTime = hardwareDto.CreateTime;
            hardwareDomain.CreateUser = hardwareDto.CreateUser;
            //转换工程名为工程id
            var projects = from r in _dataContext.Set<Project>() where r.Name == hardwareDto.Project select r;
            foreach (var project in projects)
            {
                hardwareDomain.ProjectID = project.ID;
            }
            //添加到表hardware
            _hardwareRepository.AddEntity(hardwareDomain);
            //查出hardware获取id号
            int id = 0;
            var hardwares = from r in _dataContext.Set<Hardware>() where r.Name == hardwareDto.Name select r;
            foreach(var hardware in hardwares)
            {
                id = hardware.ID;
            }
            //添加items到表itembaseonhardware
            for(int i=0; i < hardwareDto.Items.Count; i++)
            {
                ItemBaseOnHardware itemBaseOnHardware = new ItemBaseOnHardware();
                itemBaseOnHardware.Name = hardwareDto.Items[i];
                itemBaseOnHardware.HardwareID = id;
                _itemBaseOnHardwareRepository.AddEntity(itemBaseOnHardware);
            }
        }
        public void DeleteDto(HardwareDto hardwareDto) 
        {

        }
        public void DeleteDtoByID(int id)
        {
            _hardwareRepository.DeleteEntityById(id);
        }
        public void UpdateDto(HardwareDto hardwareDto)
        {
            Hardware hardware = new Hardware();
            hardware.ID = hardwareDto.ID;//这里的ID必须给值，不然更新不到数据库
            hardware.Name = hardwareDto.Name;
            hardware.CreateTime = hardwareDto.CreateTime;
            hardware.CreateUser = hardwareDto.CreateUser;
            //转换工程名为id
            var projects = from r in _dataContext.Set<Project>() where r.Name == hardwareDto.Project select r;
            foreach (var project in projects)
            {
                hardware.ProjectID = project.ID;
            }
            _hardwareRepository.UpdateEntity(hardware);
        }
        public HardwareDto GetDtoByID(int id)
        {
            HardwareDto hardwareDto = new HardwareDto();
            var hardwareDomain = _hardwareRepository.GetEntityByID(id);
            hardwareDto.ID = hardwareDomain.ID;//这个ID不用给值，到时候返回也拿得到
            hardwareDto.Name = hardwareDomain.Name;
            hardwareDto.CreateTime = hardwareDomain.CreateTime;
            hardwareDto.CreateUser = hardwareDomain.CreateUser;
            //转换id为项目名
            var projects = from r in _dataContext.Set<Project>() where r.ID == hardwareDomain.ID select r;
            foreach (var project in projects)
            {
                hardwareDto.Project = project.Name;
            }
            return hardwareDto;
        }
        public List<HardwareDto> GetHardwareDtos()
        {
            List<HardwareDto> hardwareDtos = new List<HardwareDto>();
            var hardwareDomains=_hardwareRepository.GetAllEntities();
            foreach (var hardwareDomain in hardwareDomains)
            {
                HardwareDto hardwareDto = new HardwareDto();
                hardwareDto.ID = hardwareDomain.ID;
                hardwareDto.Name = hardwareDomain.Name;
                hardwareDto.CreateTime = hardwareDomain.CreateTime;
                hardwareDto.CreateUser = hardwareDomain.CreateUser;
                //转换工程id为工程名
                var projects = from r in _dataContext.Set<Project>() where r.ID == hardwareDomain.ProjectID select r;
                foreach (var project in projects)
                {
                    hardwareDto.Project = project.Name;
                }
                hardwareDtos.Add(hardwareDto);
            }
            return hardwareDtos;
        }
    }
}
