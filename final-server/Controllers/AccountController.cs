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
        private readonly KeepsService _kserv;

        public AccountController(ProfilesService psService, VaultsService vserv, KeepsService kserv)
        {
            _psService = psService;
            _vserv = vserv;
            _kserv = kserv;
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
                return Ok(_vserv.GetVaultsByAccountId(userInfo.Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }

        }

        [HttpGet("keeps")]
        public async Task<ActionResult<Keep>> GetKeepsByAccountIdAsync()
        {
            try
            {
                Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
                return Ok(_kserv.GetKeepsByProfileId(userInfo.Id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }

        }
    }
}