using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo_mail_marketing.Data;
using Microsoft.EntityFrameworkCore;

namespace demo_mail_marketing.Models
{
    public class MailDemoDbContext : DbContext
    {
        public MailDemoDbContext(DbContextOptions<MailDemoDbContext> options)
            : base(options)
        { }

        public DbSet<MailData>? MailDatas { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<MailTemplate>? MailTemplates{ get; set; }
    }
}