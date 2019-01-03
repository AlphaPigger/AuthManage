using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthManage.Application.DTOModel.BusinessModel;
using AuthManage.Application.IAppServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace AuthManage.MVC.Controllers
{
    public class HardwareController : ControllerBase
    {
        //中间数据
        private static HardwareDto _hardwareDto = new HardwareDto();
        //依赖注入
        private IHardwareAppService _hardwareAppService;
        private IProjectAppService _projectAppService;
        private IItemAppService _itemAppService;
        private IItemBaseOnHardwareAppService _itemBaseOnHardwareAppService;
        public HardwareController(IHardwareAppService hardwareAppService,IProjectAppService projectAppService,IItemAppService itemAppService,IItemBaseOnHardwareAppService itemBaseOnHardwareAppService)
        {
            _hardwareAppService = hardwareAppService;
            _projectAppService = projectAppService;
            _itemAppService = itemAppService;
            _itemBaseOnHardwareAppService = itemBaseOnHardwareAppService;
        }
        //查询
        public IActionResult Index(int Page=1,int PageSize=5)
        {
            ViewBag.PageSize = PageSize;
            var hardwareDtos=_hardwareAppService.GetHardwareDtos();
            return View(hardwareDtos.ToPagedList(Page,PageSize));
        }
        //增加
        public IActionResult Add()
        {
            GenerateViewDatas();
            return View();
        }
        [HttpPost]
        public IActionResult Add(HardwareDto hardwareDto)
        {
            if (ModelState.IsValid)
            {
                hardwareDto.CreateTime = DateTime.Now.ToString();
                hardwareDto.CreateUser = HttpContext.Session.GetString("CurrentUser");
                _hardwareAppService.AddDto(hardwareDto);
                return RedirectToAction("Index","Hardware");
            }
            GenerateViewDatas();
            return View(hardwareDto);
        }
        //删除
        public IActionResult Delete(int id)
        {
            _hardwareAppService.DeleteDtoByID(id);
            return RedirectToAction("Index","Hardware");
        }
        //修改
        public IActionResult Edit(int id)
        {
            var hardwareDto = _hardwareAppService.GetDtoByID(id);
            GenerateTempDatas(hardwareDto);
            GenerateViewDatas();
            return View(hardwareDto);
        }
        [HttpPost]
        public IActionResult Edit(HardwareDto hardwareDto)
        {
            if (ModelState.IsValid)
            {
                hardwareDto.CreateTime=_hardwareDto.CreateTime;
                hardwareDto.CreateUser = _hardwareDto.CreateUser;
                _hardwareAppService.UpdateDto(hardwareDto);
                return RedirectToAction("Index","Hardware");
            }
            GenerateViewDatas();
            return View(hardwareDto);
        }
        //管理条目
        //public IActionResult Management(int HardwareID)//硬件ID
        //{
        //    var itemBaseOnHardwareDtos=_itemBaseOnHardwareAppService.GetDtosByHardwareID(HardwareID);
        //    return View(itemBaseOnHardwareDtos);
        //}

        private void GenerateTempDatas(HardwareDto hardwareDto)
        {
            _hardwareDto.CreateTime = hardwareDto.CreateTime;
            _hardwareDto.CreateUser = hardwareDto.CreateUser;
        }

        private void GenerateViewDatas()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            //获取所有项目
            var projects=_projectAppService.GetAllDtos();
            foreach (var project in projects)
            {
                selectListItems.Add(new SelectListItem(project.Name,project.Name));
            }
            ViewData["Projects"] = selectListItems;
            //获取所有条目
            selectListItems = new List<SelectListItem>();
            var items = _itemAppService.GetAllDtos();
            foreach (var item in items)
            {
                selectListItems.Add(new SelectListItem(item.Name,item.Name));
            }
            ViewData["Items"] = selectListItems;
        }
    }
}