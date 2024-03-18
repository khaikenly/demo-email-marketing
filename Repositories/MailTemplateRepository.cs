using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;
using demo_mail_marketing.IRepositories;
using demo_mail_marketing.Models;
using Microsoft.EntityFrameworkCore;

namespace demo_mail_marketing.Repositories
{
    public class MailTemplateRepository : Repository<MailTemplate>, IMailTemplateRepository
    {
        public MailTemplateRepository(MailDemoDbContext context) : base(context)
        { }

        private MailDemoDbContext MailDemoDbContext
        {
            get { return Context as MailDemoDbContext; }
        }

        public async Task<int> CreateMailTemplateAsync(MailTemplateModel mailTemplateModel)
        {
            var mailTemplateEntity = new MailTemplate
            {
               name = mailTemplateModel.name,
               template = mailTemplateModel.template,
            };

            MailDemoDbContext.Add<MailTemplate>(mailTemplateEntity);
            await MailDemoDbContext.SaveChangesAsync();

            return mailTemplateEntity.Id;
        }

        public async Task<IEnumerable<MailTemplateModel>> GetAllMailTemplatesAsync()
        {
            var mailTemplates = await MailDemoDbContext.MailTemplates.ToListAsync();
            var mailTemplateModels = mailTemplates.Select(mailTemplate => new MailTemplateModel
            {
                Id = mailTemplate.Id,
                name = mailTemplate.name,
                template = mailTemplate.template,
            });

            return mailTemplateModels;
        }

        public async Task<MailTemplateModel> GetMailTemplateByIdAsync(int id)
        {
            var result = await MailDemoDbContext.MailTemplates.Where(w => w.Id == id).Select( m => new MailTemplateModel {
                Id = m.Id,
                name = m.name,
                template = m.template,
            }).FirstOrDefaultAsync();

            return result;
        }
    }
}