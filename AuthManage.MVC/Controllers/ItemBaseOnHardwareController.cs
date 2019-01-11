using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using AuthManage.Domain.DomainModel.BusinessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class ItemBaseOnHardwareController : ControllerBase
    {
        private static int HardwareID=0;
        //依赖注入
        private IItemBaseOnHardwareAppService _itemBaseOnHardwareAppService;
        private IRecordAppService _recordAppService;
        private IItemAppService _itemAppService;
        public ItemBaseOnHardwareController(IItemBaseOnHardwareAppService itemBaseOnHardwareAppService,IRecordAppService recordAppService,IItemAppService itemAppService)
        {
            _itemBaseOnHardwareAppService = itemBaseOnHardwareAppService;
            _recordAppService = recordAppService;
            _itemAppService = itemAppService;
        }
        //查询
        public IActionResult Index(int Page=1,int PageSize=5,int ID=0)//这里ID为硬件ID标识
        {
            ViewBag.PageSize = PageSize;
            if (ID != 0)
            {
                HardwareID = ID;
            }
            var dtos=_itemBaseOnHardwareAppService.GetDtosByHardwareID(HardwareID);
            return View(dtos.ToPagedList(Page,PageSize));
        }
        //增加
        public IActionResult Add()
        {
            GenerateViewDatas();
            return View();
        }
        [HttpPost]
        public IActionResult Add(ItemBaseOnHardwareDto itemBaseOnHardwareDto)
        {
            if (ModelState.IsValid)
            {
                _itemBaseOnHardwareAppService.AddDto(itemBaseOnHardwareDto,HardwareID);
                return RedirectToAction("Index");
            }
            GenerateViewDatas();
            return View(itemBaseOnHardwareDto);
        }
        //删除
        public IActionResult Delete(int id)
        {
            _itemBaseOnHardwareAppService.DeleteDtoById(id);
            return RedirectToAction("Index");
        }
        //修改
        public IActionResult Edit(int id)
        {
            var dto=_itemBaseOnHardwareAppService.GetDtoByID(id);
            GenerateViewDatas();
            return View(dto);
        }
        [HttpPost]
        public IActionResult Edit(ItemBaseOnHardwareDto itemBaseOnHardwareDto)
        {
            if (ModelState.IsValid)
            {
                //获取当前用户
                string CurrentUser = HttpContext.Session.GetString("CurrentUser");
                _itemBaseOnHardwareAppService.UpdateDto(itemBaseOnHardwareDto, CurrentUser, HardwareID);//传入外键
                return RedirectToAction("Index","ItemBaseOnHardware");
            }
            GenerateViewDatas();
            return View(itemBaseOnHardwareDto);
        }

        //获取记录
        public IActionResult Record(int ItemBaseOnHardwareID)
        {
            var records=_recordAppService.GetDtosByItemBaseOnHardwareID(ItemBaseOnHardwareID);
            return Content(JsonConvert.SerializeObject(records));
        }


        private void GenerateViewDatas()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem("未测试","未测试"));
            selectListItems.Add(new SelectListItem("正常","正常"));
            selectListItems.Add(new SelectListItem("异常", "异常"));
            ViewData["Status"] = selectListItems;
            selectListItems = new List<SelectListItem>();
            //获取所有条目项
            var items=_itemAppService.GetAllDtos();
            foreach(var item in items)
            {
                selectListItems.Add(new SelectListItem(item.Name,item.Name));
            }
            ViewData["Items"] = selectListItems;
        }
    }
}