using AutoMapper;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Enums;
using ConversionService.Core.Helpers;
using ConversionService.Core.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Infrastructure.Services.Impl
{
    public interface IUserService
    {
        Task<ApiCommonResponse> RegisterUser(UserRequest userRequest);
        Task<ApiCommonResponse> GetAllUsers();
        Task<ApiCommonResponse> GetUserById(long id);
        Task<ApiCommonResponse> UpdateUser(long id, UserRequest userRequest);
        Task<ApiCommonResponse> UserLogin(LoginRequest loginRequest);
        Task<ApiCommonResponse> DeactivateUser(long id);

    }
}
