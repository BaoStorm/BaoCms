using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BaoCMS.Web.Filters;

namespace BaoCMS.Web.ApiControllers
{

    [Produces("application/json")]
    [ServiceFilter(typeof(ApiExceptionFilter))]
    public class BaseApiController : Controller
    {

    }
}