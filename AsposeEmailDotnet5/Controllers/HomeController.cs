using AsposeEmailDotnet5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace AsposeEmailDotnet5.Controllers
{
    public class HomeController : BaseController
    {
        public override string Product => string.Empty;

        public HomeController(IMemoryCache cache) : base(cache)
        {
        }

        public IActionResult Default()
        {
            ViewBag.PageTitle = Resources["emailConversionPageTitle"];
            ViewBag.MetaDescription = Resources["emailConversionMetaDescription"];

            var model = new LandingPageModel(this);
            return View(model);
        }
    }
}
