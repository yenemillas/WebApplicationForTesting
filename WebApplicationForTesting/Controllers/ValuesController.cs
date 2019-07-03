using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationForTesting.Resources;
using WebApplicationForTesting.Services;

namespace WebApplicationForTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public ValuesController( IMessageService messageService)
        {
            _messageService = messageService;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_messageService.GetMessage(Models.MessageTypeEnum.Type1, new System.Globalization.CultureInfo("fr-FR")));
        }

       
    }
}
