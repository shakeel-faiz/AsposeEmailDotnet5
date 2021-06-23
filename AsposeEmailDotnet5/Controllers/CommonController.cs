using AsposeEmailDotnet5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.IO;

namespace AsposeEmailDotnet5.Controllers
{
    public class CommonController : BaseController
    {

        public CommonController(IMemoryCache cache) : base(cache)
        {
        }

        public override string Product => string.Empty;

        [HttpGet]
        public FileResult Download()
        {
            byte[] convertResult = HttpContext.Session.Get(SessionKeyConvertResult);
            string outputFileName = HttpContext.Session.GetString(SessionKeyOutputFileName);

            MemoryStream ms = new MemoryStream(convertResult);
            return File(ms, "application/octet-stream", outputFileName);
        }

    }
}
