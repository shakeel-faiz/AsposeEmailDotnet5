using AsposeEmailDotnet5.Controllers;
using System.Collections.Generic;

namespace AsposeEmailDotnet5.Models
{
    public class LandingPageModel
    {
        public BaseController Controller;
        public Dictionary<string, string> Resources { get; set; }

        public LandingPageModel(BaseController controller)
        {
            Controller = controller;
            Resources = controller.Resources;
        }
    }
}