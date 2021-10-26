using CoMute.Models;
using CoMute.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Controllers
{
    public class UserController : ControllerBase
    {
        private IUserService _userRestService;
        //eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InNlY2hhYmFtb3RAZ21haWwuY29tIiwibmJmIjoxNjM1MDY4OTQxLCJleHAiOjE2Mzc2NjA5NDEsImlhdCI6MTYzNTA2ODk0MX0.HtISIRIlWFfIENkudR7iDfr36Q8AX1WJ6iv_tEORZ-M
        public UserController(IUserService userRestService)
        {
            _userRestService = userRestService;
        }

        [HttpGet]
        [Authorize]
        [Route("[controller]/[action]")]
        public IActionResult Authenticated()
        {
            return Ok();
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<ActionResult<IdentityResult>> Register(RegisterUserRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _userRestService.Create(model));
                }
                catch (Exception)
                {
                    //TODO: Log exception
                    return StatusCode(500);
                }
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<ActionResult<AuthenticationResult>> Authenticate([FromBody] UserSignInRequest model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _userRestService.Authenticate(model));
                }
                catch (Exception)
                {
                    //TODO: Log exception
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
