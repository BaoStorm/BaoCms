using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaoCMS.Web.ApiControllers
{
    [Route("api/Test")]
    public class TestController : BaseApiController
    {
        [HttpGet]
        [Route("Index")]
        public JsonResult Index()
        {
            return new JsonResult("Hello");
        }

        [HttpGet]
        [Route("Ex")]
        public JsonResult Ex(int i)
        {
            return new JsonResult(new TestInfo() { Index = i });
        }
    }

    public class TestInfo
    {
        public int Index { set; get; }
    }
}