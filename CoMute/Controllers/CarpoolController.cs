using CoMute.Models;
using CoMute.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Controllers
{
    public class CarpoolController : ControllerBase
    {
        private ICarpoolService _carpoolService;

        public CarpoolController(ICarpoolService carpoolService)
        {
            _carpoolService = carpoolService;
        }

        [Authorize]
        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<ActionResult<CreateCarpoolResponse>> Create(CreateCarpoolRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _carpoolService.Create(request));
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpGet]
        [Route("[controller]/Read/[action]")]
        public ActionResult<List<Carpool>> Owners(string userName) 
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                try
                {
                    return Ok(_carpoolService.ReadOwnersCarpools(userName));
                }
                catch (Exception)
                {
                    return StatusCode(00);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("[controller]/Read/[action]")]
        public ActionResult<List<Carpool>> Joined(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                try
                {
                    return Ok(_carpoolService.ReadJoinedCarpools(userName));
                }
                catch (Exception)
                {
                    return StatusCode(00);
                }
            }
            else
            {
                return BadRequest();
            }
        }


        [Authorize]
        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<ActionResult<JoinOrLeaveCarpoolResponse>> Join(JoinOrLeaveCarpoolRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _carpoolService.JoinCarPool(model));
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<ActionResult<JoinOrLeaveCarpoolResponse>> Leave(JoinOrLeaveCarpoolRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _carpoolService.LeaveCarPool(model));
                }
                catch (Exception)
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
