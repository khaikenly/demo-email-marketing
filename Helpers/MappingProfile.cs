using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using demo_mail_marketing.Data;
using demo_mail_marketing.Models;

namespace demo_mail_marketing.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MailData, MailDataModel>().ReverseMap();
            CreateMap<MailTemplate, MailTemplateModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}