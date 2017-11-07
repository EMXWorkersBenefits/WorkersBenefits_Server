using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace EMX.WorkersBenefits.MVC.Controllers
{
    public class ProductsApiController : ApiController
    {
        public OkResult Test()
        {
            return Ok();
        }
    }
}
