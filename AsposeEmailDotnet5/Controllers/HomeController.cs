using AsposeEmailDotnet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AsposeEmailDotnet5.Controllers
{
    public class HomeController : BaseController
    {
        public override string Product => string.Empty;

        public HomeController(IMemoryCache cache):base(cache)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Default()
        {
            ViewBag.PageTitle = Resources["emailConversionPageTitle"];
            ViewBag.MetaDescription = Resources["emailConversionMetaDescription"];

            var model = new LandingPageModel(this);
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
