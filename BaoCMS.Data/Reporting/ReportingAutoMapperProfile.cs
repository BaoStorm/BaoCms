using AutoMapper;
using BaoCMS.Data.Entities;
using BaoCMS.Reporting.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaoCMS.Data.Reporting
{
    public class ReportingAutoMapperProfile : Profile
    {
        public ReportingAutoMapperProfile()
        {
            //CreateMap<App, AppAdminModel>();
            //CreateMap<App, AppAdminListModel>();
            //CreateMap<EmailAccount, EmailAccountModel>();
            //CreateMap<Language, LanguageInfo>();
            //CreateMap<Language, LanguageAdminModel>();
            //CreateMap<Menu, MenuAdminModel>();
            //CreateMap<ModuleType, ModuleTypeAdminModel>();
            //CreateMap<ModuleType, ModuleTypeAdminListModel>();
            //CreateMap<Page, PageAdminModel>();
            //CreateMap<Page, PageAdminListModel>();
            //CreateMap<PageLocalisation, PageLocalisationAdminListModel>();
            //CreateMap<Site, SiteAdminModel>();
            //CreateMap<SiteLocalisation, SiteLocalisationAdminModel>();
            //CreateMap<Site, SiteInfo>();
            //CreateMap<Theme, ThemeAdminModel>();
            //CreateMap<Theme, ThemeInfo>();
            //CreateMap<User, UserAdminModel>();
            //CreateMap<User, UserAdminListModel>();
            CreateMap<User, UserInfo>();
        }
    }
}
