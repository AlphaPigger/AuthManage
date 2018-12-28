using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel.BusinessModel;
using AuthManage.Domain.IRepositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthManage.Application.AppServices
{
    public class ProjectAppService:IProjectAppService
    {
        //依赖注入
        private IProjectRepository _projectRepository;
        public ProjectAppService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public void AddDto(ProjectDto dto)
        {
            _projectRepository.AddEntity(Mapper.Map<Project>(dto));
        }
        public void DeleteDto(ProjectDto dto)
        {

        }
        public void DeleteDtoById(int id)
        {
            _projectRepository.DeleteEntityById(id);
        }
        public void UpdateDto(ProjectDto dto)
        {
            _projectRepository.UpdateEntity(Mapper.Map<Project>(dto));
        }
        public ProjectDto GetDtoByID(int id)
        {
            return Mapper.Map<ProjectDto>(_projectRepository.GetEntityByID(id));
        }
        public List<ProjectDto> GetAllDtos()
        {
            var projectDomains = _projectRepository.GetAllEntities();
            return Mapper.Map<List<ProjectDto>>(projectDomains);
        }
    }
}
