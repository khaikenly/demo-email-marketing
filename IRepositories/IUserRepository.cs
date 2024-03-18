using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;
using demo_mail_marketing.Models;

namespace demo_mail_marketing.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetByEmailAsync(string email);
    }
}