using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using YUI.Models;
using YUI.Services;

namespace YUI.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        readonly TestService testService = new TestService();
        [HttpGet, Route]
        public List<Test> SelectAll()
        {
            return testService.SelectAll();
        }
        [HttpPost, Route]
        public int Create(TestCreate model)
        {
            return testService.Create(model);
        }
    }
}