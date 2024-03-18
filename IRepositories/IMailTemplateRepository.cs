using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;
using demo_mail_marketing.Models;

namespace demo_mail_marketing.IRepositories
{
    public interface IMailTemplateRepository : IRepository<MailTemplate>
    { 
        Task<IEnumerable<MailTemplateModel>> GetAllMailTemplatesAsync();
        Task<int> CreateMailTemplateAsync(MailTemplateModel mailTemplateModel);
        Task<MailTemplateModel> GetMailTemplateByIdAsync(int id);
    }
}