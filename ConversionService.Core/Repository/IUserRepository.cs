using ConversionService.Core.Entities;
using ConversionService.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ConversionService.Core.Repository.Impl
{
    public interface  IUserRepository
    {

        Task<bool> DeactivateUser(User user);
        Task<IEnumerable<User>> FindAllUsers();
        Task<User> FindUserById(long Id);
        Task<User> FindUserByUserName(string username);
        Task<User> SaveUser(User user);
        Task<User> UpdateUser(User user);
      



    }
}
