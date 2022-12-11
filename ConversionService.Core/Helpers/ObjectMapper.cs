using AutoMapper;
using ConversionService.Core.Dtos.Request;
using ConversionService.Core.Dtos.Response;
using ConversionService.Core.Entities;
using ConversionService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionService.Core.Helpers
{
    public class ObjectMapper
    { 
        public static ConversionUnit conversionUnitRequestMapper(ConversionRequest request)
        {

            return new ConversionUnit()
            {
                UnitCategory = request.UnitCategory,
                UnitNameOfOrigin = request.UnitNameOfOrigin,
                UnitNameOfDestination = request.UnitNameOfDestination,
                ValuePerUnit = request.ValuePerUnit,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = request.userId

            };
        }

        public static ConversionAction conversionActionRequestMapper(ConversionActionRequest request)
        {

            return new ConversionAction()
            {
                UnitCategory = request.UnitCategory,
                UnitNameOfOrigin = request.UnitNameOfOrigin,
                UnitNameOfDestination = request.UnitNameOfDestination,
                ValuePerUnit = request.ValuePerUnit,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                UserId = request.UserId,
                valueToConvert = request.valueToConvert,
                ValueResult = request.ValueResult

            };
        }

        public static User userRequestMapper(UserRequest request)
        {

            return new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Password = request.Password,
                CreatedAt = DateTime.UtcNow,
                IsActive=true,
            };
        }


        public static User userUpdateRequestMapper(User user, UserRequest userRequest)
        {
            user.FirstName = userRequest.FirstName ?? user.FirstName;
            user.LastName = userRequest.LastName ?? user.LastName;
            user.Username = userRequest.Username ?? user.Username;
            user.Password = userRequest.Password ?? user.Password;
            user.UpdatedAt = DateTime.UtcNow;
            return user;

        }

        public static ConversionUnit conversionUnitUpdatedRequestMapper(ConversionUnit conversionUnit,ConversionRequest conversionRequest)
        {
            conversionUnit.UnitCategory = conversionRequest.UnitCategory == 0 ? conversionUnit.UnitCategory : conversionRequest.UnitCategory;
            conversionUnit.ValuePerUnit = conversionRequest.ValuePerUnit == 0 ? conversionUnit.ValuePerUnit : conversionRequest.ValuePerUnit;
            conversionUnit.UnitNameOfOrigin = conversionRequest.UnitNameOfOrigin ?? conversionUnit.UnitNameOfOrigin;
            conversionUnit.UnitNameOfDestination = conversionRequest.UnitNameOfDestination ?? conversionUnit.UnitNameOfDestination;
            conversionUnit.UpdatedAt = DateTime.UtcNow;

           return conversionUnit;
                
        
        }
        
    }
}
