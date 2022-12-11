using ConversionAPI.Infrastructure.Services;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using ConversionService.Infrastructure.Services.Impl;
using Microsoft.AspNetCore.Mvc;

namespace ConversionService.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ApiCommonResponse> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }


        [HttpGet("GetUserById/{id}")]
        public async Task<ApiCommonResponse> GetUserById(long id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpPost("RegisterUser")]
        public async Task<ApiCommonResponse> AddNewUser([FromBody] UserRequest userRequest)
        {
            return await _userService.RegisterUser(userRequest);
        }

        [HttpPost("LoginUser")]
        public async Task<ApiCommonResponse> LoginUser([FromBody] LoginRequest loginRequest)
        {
            return await _userService.UserLogin(loginRequest);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<ApiCommonResponse> UpdateUserInfo(long id, UserRequest userRequest)
        {
            return await _userService.UpdateUser(id, userRequest);
        }

        [HttpDelete("DeactivateUser/{id}")]
        public async Task<ApiCommonResponse> DeactivateUser(int id)
        {
            return await _userService.DeactivateUser(id);
        }
    }
}
