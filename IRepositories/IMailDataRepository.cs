using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;
using demo_mail_marketing.Models;

namespace demo_mail_marketing.IRepositories
{
    public interface IMailDataRepository : IRepository<MailData>
    { 
        Task<IEnumerable<MailDataModel>> GetAllMailDatasAsync();

        Task<int> CreateMailDataAsync(MailDataModel mailData);

        Task<bool> UpdateMailDataStatusByAsync(int id, bool status);   
    }
}