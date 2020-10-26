using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoTelManger_MVCFM.Models;

namespace HoTelManger_MVCFM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Home()
        {
            List<RoomsInfo> roomList = Listinfo.GetList();
            return View(roomList);
        }
    }
}