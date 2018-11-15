using AuthManage.Application.DTOModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel;
using AuthManage.Domain.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class DepartmentAppService:IDepartmentAppService
    {
        //依赖注入
        private IDepartmentRepository _departmentRepository;
        public DepartmentAppService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public void AddDto(DepartmentDto dto)
        {
            _departmentRepository.AddEntity(Mapper.Map<Department>(dto));
        }
        public void DeleteDto(DepartmentDto dto)
        {

        }
        public void DeleteDtoById(int id)
        {
            _departmentRepository.DeleteEntityById(id);
        }
        public void UpdateDto(DepartmentDto dto)
        {
            _departmentRepository.UpdateEntity(Mapper.Map<Department>(dto));
        }
        public DepartmentDto GetDtoByID(int id)
        {
            return Mapper.Map<DepartmentDto>(_departmentRepository.GetEntityByID(id));
        }
        public List<DepartmentDto> GetAllDtos()
        {
            return Mapper.Map<List<DepartmentDto>>(_departmentRepository.GetAllEntities());
        }
    }
}
