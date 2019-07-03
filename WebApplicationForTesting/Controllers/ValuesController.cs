using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForTesting.Resources;

namespace WebApplicationForTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly LocService _locService;

        public ValuesController(LocService locService)
        {
            _locService = locService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            var resourceName = "Customer";

            var fr = _locService.GetLocalized(resourceName, new System.Globalization.CultureInfo("fr-FR"));
            var us = _locService.GetLocalized(resourceName, new System.Globalization.CultureInfo("us-US"));

            return new string[] { fr, us };
        }

       
    }
}
