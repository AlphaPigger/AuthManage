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
    public class ItemAppService:IItemAppService
    {
        private IItemRepository _itemRepository;
        public ItemAppService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public void AddDto(ItemDto itemDto)
        {
            _itemRepository.AddEntity(Mapper.Map<Item>(itemDto));
        }
        public void DeleteDtoByID(int id)
        {
            _itemRepository.DeleteEntityById(id);
        }
        public void Update(ItemDto itemDto)
        {
            _itemRepository.UpdateEntity(Mapper.Map<Item>(itemDto));
        }
        public ItemDto GetDtoByID(int id)
        {
            return Mapper.Map<ItemDto>(_itemRepository.GetEntityByID(id));
        }
        public List<ItemDto> GetAllDtos()
        {
            return Mapper.Map<List<ItemDto>>(_itemRepository.GetAllEntities());
        }
    }
}
