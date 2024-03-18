using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using demo_mail_marketing.Data;
using demo_mail_marketing.IRepositories;
using demo_mail_marketing.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_mail_marketing.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MailDemoDbContext context) : base(context)
        { }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await MailDemoDbContext.Users.Select(u => new UserModel {
                Id = u.Id,
                Email = u.Email,
                Name = u.Name,
             }).ToListAsync();
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            return await MailDemoDbContext.Users.Select(u => new UserModel {
                Id = u.Id,
                Email = u.Email,
                Name = u.Name,
            }).SingleOrDefaultAsync(u => u.Email == email);
        }

        private MailDemoDbContext MailDemoDbContext
        {
            get { return Context as MailDemoDbContext; }
        }
    }
}