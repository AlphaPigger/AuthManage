using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class ItemController : Controller
    {
        private static ItemDto _ItemDto = new ItemDto();

        private IItemAppService _itemAppService;
        public ItemController(IItemAppService itemAppService)
        {
            _itemAppService = itemAppService;
        }

        public IActionResult Index(int Page=1,int PageSize=5)
        {
            ViewBag.PageSize = PageSize;
            var itemDtos=_itemAppService.GetAllDtos();
            return View(itemDtos.ToPagedList(Page,PageSize));
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ItemDto itemDto)
        {
            if (ModelState.IsValid)
            {
                itemDto.CreateTime = DateTime.Now.ToString();
                itemDto.CreateUser = HttpContext.Session.GetString("CurrentUser");
                _itemAppService.AddDto(itemDto);
                return RedirectToAction("Index","Item");
            }
            return View(itemDto);
        }
        public IActionResult Delete(int id)
        {
            _itemAppService.DeleteDtoByID(id);
            return RedirectToAction("Index","Item");
        }
        public IActionResult Edit(int id)
        {
            var itemDto=_itemAppService.GetDtoByID(id);
            GenerateTempDatas(itemDto);
            return View(itemDto);
        }
        [HttpPost]
        public IActionResult Edit(ItemDto itemDto)
        {
            if (ModelState.IsValid)
            {
                itemDto.CreateTime=_ItemDto.CreateTime;
                itemDto.CreateUser = _ItemDto.CreateUser;
                _itemAppService.Update(itemDto);
                return RedirectToAction("Index","Item");
            }
            return View(itemDto);
        }

        private void GenerateTempDatas(ItemDto itemDto)
        {
            _ItemDto.CreateTime = itemDto.CreateTime;
            _ItemDto.CreateUser = itemDto.CreateUser;
        }
    }
}