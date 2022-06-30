using System;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Infrastructure;
using OnlineBabysitterAssistant.Web.Application.Interfaces;
using OnlineBabysitterAssistant.Web.Application.Services;
using OnlineBabysitterAssistant.Web.Appplication.Configurations.Helpers;
using OnlineBabysitterAssistant.Web.Appplication.Interfaces;
using OnlineBabysitterAssistant.Web.Appplication.Services;

namespace OnlineBabysitterAssistant.Web.Application.Configurations.Extensions
{
	public static class ServiceRegisterExtension
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IJwtUtils, JwtUtils>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IParentService, ParentService>();
			services.AddScoped<IBabysitterService, BabysitterService>();
		}
		public static void RegisterMappers(this IServiceCollection services)
        {
			services.AddAutoMapper(
				typeof(UserProfile),
				typeof(ChildProfile),
				typeof(ActivityProfile));
        }
	}
}

