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
    public class MailDataRepository : Repository<MailData>, IMailDataRepository
    {
        public MailDataRepository(MailDemoDbContext context) : base(context)
        { }

        private MailDemoDbContext MailDemoDbContext
        {
            get { return Context as MailDemoDbContext; }
        }

        public async Task<int> CreateMailDataAsync(MailDataModel mailData)
        {
            var mailDataEntity = new MailData
            {
                Bcc = mailData.Bcc,
                Cc = mailData.Cc,
                From = mailData.From,
                Subject = mailData.Subject,
                To = mailData.To,
                Body = mailData.Body,
            };

            MailDemoDbContext.Add<MailData>(mailDataEntity);
            await MailDemoDbContext.SaveChangesAsync();

            return mailDataEntity.Id;
        }

        public async Task<IEnumerable<MailDataModel>> GetAllMailDatasAsync()
        {
             return await MailDemoDbContext.MailDatas.Select(d => new MailDataModel {
                Bcc = d.Bcc,
                Body = d.Body,
                Cc = d.Cc,
                From = d.From,
                Id = d.Id,
                Subject = d.Subject,
                To = d.To
             }).ToListAsync();
        }

        public async Task<bool> UpdateMailDataStatusByAsync(int id, bool status)
        {
            var mailData = await MailDemoDbContext.MailDatas.FirstOrDefaultAsync(d => d.Id == id);
            if (mailData == null)
            {
                return false;
            }

            mailData.Sent = status;
            MailDemoDbContext.Entry(mailData).State = EntityState.Modified;
            await MailDemoDbContext.SaveChangesAsync();

            return true;
        }
    }
}
