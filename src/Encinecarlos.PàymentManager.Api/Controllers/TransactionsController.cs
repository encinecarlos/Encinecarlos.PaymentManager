using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Encinecarlos.PàymentManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTransaction() 
        {
            return Ok();
        }
    }
}
