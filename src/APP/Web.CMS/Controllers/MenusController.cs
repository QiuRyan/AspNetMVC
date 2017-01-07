using CMS.Business;
using CMS.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.CMS.Controllers
{
    public class MenusController : Controller
    {
        MenuBll bll = new MenuBll();
        // GET: Menus
        public ActionResult Index()
        {
            var menulist = bll.GetMenuList(SharedConsts.SYSTEMID);
            return View(menulist);
        }
    }
}