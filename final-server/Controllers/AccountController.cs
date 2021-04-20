using System.Collections.Generic;
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
        private readonly VaultsService _vserv;

        public AccountController(ProfilesService psService, VaultsService vserv)
        {
            _psService = psService;
            _vserv = vserv;
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

        [HttpGet("vaults")]
        public async Task<ActionResult<Vault>> GetVaultsByAccountIdAsync()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_vserv.GetVaultsByProfileId(userInfo.Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }

        }
    }
}