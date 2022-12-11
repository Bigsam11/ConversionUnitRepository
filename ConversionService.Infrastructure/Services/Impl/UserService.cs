using AutoMapper;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Entities;
using ConversionService.Core.Enums;
using ConversionService.Core.Helpers;
using ConversionService.Core.Repository;
using ConversionService.Core.Repository.Impl;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Infrastructure.Services.Impl
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuditRepository _auditRepository;
        private readonly IHttpContextAccessor _httpRequest;
        public UserService(IUserRepository userRepository, IAuditRepository _auditRepository, IHttpContextAccessor httpRequest)
        {
            this._userRepository = userRepository;
            this._auditRepository = _auditRepository;
            this._httpRequest = httpRequest;    
            
        }

        public async Task<ApiCommonResponse> RegisterUser(UserRequest userRequest)
        {

            var userInstance = ObjectMapper.userRequestMapper(userRequest);
            
            var savedUser = await _userRepository.SaveUser(userInstance);
            if (savedUser == null)
            {
                return CommonResponse.Send(ResponseCodes.FAILURE);
            }
            
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), JsonConvert.SerializeObject(userRequest), JsonConvert.SerializeObject(savedUser));
            return CommonResponse.Send(ResponseCodes.SUCCESS, savedUser, ResponseMessage.UserSuccessFullySavedMessage);
        }

        public async Task<ApiCommonResponse> GetAllUsers()
        {
            var users = await _userRepository.FindAllUsers();
            if (users == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), "", JsonConvert.SerializeObject(users));
            return CommonResponse.Send(ResponseCodes.SUCCESS, users, ResponseMessage.UserSuccessFullyFetchedMessage);
        }

        public async Task<ApiCommonResponse> GetUserById(long id)
        {
            var userInstance = await _userRepository.FindUserById(id);
            if (userInstance == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_USER_PROFILE_FOUND); ;
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(userInstance));
            return CommonResponse.Send(ResponseCodes.SUCCESS, userInstance, ResponseMessage.UserSuccessFullyFetchedMessage);
        }

        public async Task<ApiCommonResponse> UserLogin(LoginRequest loginRequest)
        {
            var userInstance = await _userRepository.FindUserByUserName(loginRequest.username);
            if (userInstance == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_USER_PROFILE_FOUND);
            }
            if (!loginRequest.password.Trim().Equals(userInstance.Password.Trim()))
            {
                return CommonResponse.Send(ResponseCodes.INVALID_LOGIN_DETAILS);
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(),JsonConvert.SerializeObject(loginRequest), JsonConvert.SerializeObject(userInstance));
            return CommonResponse.Send(ResponseCodes.SUCCESS, userInstance, ResponseMessage.UserSuccessFullyFetchedMessage);

        }



        public async Task<ApiCommonResponse> UpdateUser(long id, UserRequest userRequest)
        {
            var userToUpdate = await _userRepository.FindUserById(id);
            if (userToUpdate == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }

            userToUpdate = ObjectMapper.userUpdateRequestMapper(userToUpdate, userRequest);

            var updatedUser = await _userRepository.UpdateUser(userToUpdate);

            if (updatedUser == null)
            {
                return CommonResponse.Send(ResponseCodes.FAILURE);
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(updatedUser) );
            return CommonResponse.Send(ResponseCodes.SUCCESS, updatedUser, ResponseMessage.UserSuccessFullyUpdatedMessage);
        }

        public async Task<ApiCommonResponse> DeactivateUser(long id)
        {
            var userToDeactivate = await _userRepository.FindUserById(id);
            if (userToDeactivate == null)
            {
                return CommonResponse.Send(ResponseCodes.NO_DATA_AVAILABLE); ;
            }

            if (!await _userRepository.DeactivateUser(userToDeactivate))
            {
                return CommonResponse.Send(ResponseCodes.FAILURE);
            }
            _auditRepository.AuditTrail(_httpRequest.HttpContext.Request.Path.ToString(), id.ToString(), JsonConvert.SerializeObject(userToDeactivate));
            return CommonResponse.Send(ResponseCodes.SUCCESS, ResponseMessage.UserSuccessFullyDeactivatedMessage);
        }

    }
}
