using AsposeEmailDotnet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AsposeEmailDotnet5.Controllers
{
    public class TestController : BaseController
    {
        public override string Product => (string)RouteData.Values["product"];

        public TestController(IMemoryCache cache) : base(cache)
        {
        }

        public string Test()
        {
            return "Test ran";
        }

    }
}
