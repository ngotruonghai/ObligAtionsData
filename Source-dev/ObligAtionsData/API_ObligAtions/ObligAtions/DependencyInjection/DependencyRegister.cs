﻿using Autofac;
using ObligAtions.Api.Interface;
using ObligAtions.Api.Repositories;
using ObligAtions.Interface;
using ObligAtions.Repositories;
using System.Reflection;

namespace ObligAtions.DependencyInjection
{
    public class DependencyRegister : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepositories>().As<IInfoUser>();
            builder.RegisterType<TokenRepository>().As<ITokenRepository>();
            builder.RegisterType<MenuItemsRepository>().As<IMenuItems>();
            builder.RegisterType<DapperRepositories>().As<IDapperExec>();
            builder.RegisterType<HistoryRepositories>().As<IHistory>();
            builder.RegisterType<ObligAtionRepositories>().As<IInfoObligAtion>();
            builder.RegisterType<LocationBranchRepositories>().As<ILocationBranch>();
            builder.RegisterType<TicketRepositories>().As<ITicketInfo>();
        }
    }
}
