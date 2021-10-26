using CoMute.Helpers;
using CoMute.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Services
{
    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IConfiguration _configuration;

        private string _secrete;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;

            _secrete = configuration["AppSettings:Secret"];
        }

        public async Task<AuthenticationResult> Authenticate(UserSignInRequest request)
        {
            SignInResult result = await  _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
            if (result.Succeeded)
            {
                return AuthenticationHelper.Authenticate(request.Email, _secrete);
            }
            else
            {
                return new AuthenticationResult { IsSuccess = false, Message = "Wrong email or Passwoed" };
            }
        }

        public async Task<IdentityResult> Create(RegisterUserRequest request)
        {
            return await _userManager.CreateAsync(new ApplicationUser(request), request.Password);
        }
    }
}
