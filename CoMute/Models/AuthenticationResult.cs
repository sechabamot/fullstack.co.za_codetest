using Newtonsoft.Json;
using System;

namespace CoMute.Models
{
    /// <summary>
    /// Authentication result returned once a user has successfuly indentified themselves.
    /// </summary>
    public class AuthenticationResult
    {

        public AuthenticationResult()
        {

        }

        public AuthenticationResult(string userName, string tokenValue)
        {
            UserName = userName;
            AccessToken = tokenValue;
            IsSuccess = true;
        }

        [JsonProperty("userName")]
        public string UserName { get; set; }
        
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
    