using Microsoft.Extensions.Caching.Memory;

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
