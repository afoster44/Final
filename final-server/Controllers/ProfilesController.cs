using System.Collections.Generic;
using final_server.Models;
using final_server.Services;
using Microsoft.AspNetCore.Mvc;

namespace final_server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _serv;
        private readonly KeepsService _kserv;
        private readonly VaultsService _vserv;

        public ProfilesController(ProfilesService serv, KeepsService kserv, VaultsService vserv)
        {
            _serv = serv;
            _kserv = kserv;
            _vserv = vserv;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> GetProfile(string id)
        {
            try
            {
                return Ok(_serv.GetProfileById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<IEnumerable<Keep>> GetKeepsByProfileId(string id)
        {
            try
            {
                return Ok(_kserv.GetKeepsByProfileId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/vaults")]
        public ActionResult<IEnumerable<Vault>> GetVaultsByProfileId(string id)
        {
            try
            {
                return Ok(_vserv.GetVaultsByProfileId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}