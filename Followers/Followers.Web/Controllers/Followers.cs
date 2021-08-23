using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FollowersController : ControllerBase
    {
        public async Task<IActionResult> Post([FromBody] User user, [FromQuery] bool isForceCreate = true)
        {
            
        }
    }
}