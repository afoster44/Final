using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using final_server.Models;
using final_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace final_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly ProfilesService _psService;

        public AccountController(ProfilesService psService)
        {
            _psService = psService;
        }

        [HttpGet]
        public async Task<ActionResult<Profile>> GetAsync()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_psService.GetOrCreateProfile(userInfo));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}