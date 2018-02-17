using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServerManage.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public IActionResult ModalAlert(string title,string alertMessage,string type)
        {
            var script = String.Format("<script>$('.modal').modal('hide');notifyMsg('{0}','{1}','{2}');</script>", title,alertMessage,type);
            return Content(script, "text/html");
        }
    }
}