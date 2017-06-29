using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaoCMS.Web.Areas.Admin.Controllers
{
    
    public class LoginController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}