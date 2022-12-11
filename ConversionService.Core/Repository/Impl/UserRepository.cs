using ConversionService.Core.Entities;
using ConversionService.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ConversionService.Core.Repository.Impl
{
    public class UserRepository: IUserRepository
    {

        private readonly DataContext _dataContext;
        public UserRepository(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<bool> DeactivateUser(User user)
        {
            user.IsActive = false;
            _dataContext.User.Update(user);
            return await SaveChanges();
        }


        public async Task<IEnumerable<User>> FindAllUsers()
        {
            return await _dataContext.User
               .Where(unit => unit.IsActive == true)
               .Include(unit => unit.ConversionUnits)
               .Include(unit => unit.ConversionActions)
               .OrderBy(unit => unit.CreatedAt)
               .ToListAsync();
        }

        public async Task<User> FindUserById(long Id)
        {

            var user = await _dataContext.User
                .Where(unit => unit.IsActive == true && unit.Id == Id)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return user;

        }

        public async Task<User> FindUserByUserName(string username)
        {

            var user = await _dataContext.User
                .Where(unit => unit.IsActive == true && unit.Username == username)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return null;
            }

            return user;

        }



        public async Task<User> SaveUser(User user)
        {
            var savedUser = await _dataContext.User.AddAsync(user);
            if (await SaveChanges())
            {
                return savedUser.Entity;
            }
            return null;
        }


        public async Task<User> UpdateUser(User user)
        {
            var updatedUser = _dataContext.User.Update(user);
            if (await SaveChanges())
            {
                return updatedUser.Entity;
            }
            return null;
        }


        private async Task<bool> SaveChanges()
        {
            try
            {
                return await _dataContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
