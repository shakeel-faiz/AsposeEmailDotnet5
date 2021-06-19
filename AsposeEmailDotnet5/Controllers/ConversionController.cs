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
    public abstract class BaseController : Controller
    {
        public abstract string Product { get; }

        public IMemoryCache Cache { get; }

        public BaseController(IMemoryCache cache)
        {
            Cache = cache;
        }

        private static void LoadDocumentToDictionary(string filePath, Dictionary<string, string> resources)
        {
            var document = new XmlDocument();
            document.Load(filePath);

            XmlNodeList nodes = document.SelectNodes("resources/res");

            foreach (XmlNode n in nodes)
            {
                string value = n.Attributes["name"].Value;
                resources[value] = n.InnerText;
            }
        }

        public Dictionary<string, string> Resources
        {
            get
            {
                Dictionary<string, string> _resources = null;

                string key = "myResources";

                bool ret = Cache.TryGetValue(key, out _resources);

                if (!ret)
                {
                    var resourceFilePath = Startup.WebHostEnvironment.ContentRootPath + "\\App_Data\\resources_EN.xml";

                    _resources = new Dictionary<string, string>();

                    LoadDocumentToDictionary(resourceFilePath, _resources);

                    Cache.Set(key, _resources);

                }

                return _resources;
            }

        }

    }

    public class ConversionController : BaseController
    {

        public ConversionController(IMemoryCache cache) : base(cache)
        {
        }

        public override string Product => (string)RouteData.Values["product"];

        public IActionResult Conversion()
        {
            var model = new ViewModel(this, "Conversion")
            {
                SaveAsComponent = true,
                MaximumUploadFiles = 3,
            };

            return View(model);
        }

    }
}
