using CoMute.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoMute.Services
{
    public interface IUserService
    {
        Task<IdentityResult> Create(RegisterUserRequest request);
        Task<AuthenticationResult> Authenticate(UserSignInRequest model);
    }
}
