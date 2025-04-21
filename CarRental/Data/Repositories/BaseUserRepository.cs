using CarRental.Data.Interfaces;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repositories
{
    public class BaseUserRepository : GenericRepository<BaseUser, ApplicationDbContext>, IBaseUser
    {
        public BaseUserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<BaseUser?> GetUser(int id)
        {
            return await dbContext.BaseUsers.SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}
