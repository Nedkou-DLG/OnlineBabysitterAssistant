using System;
using AutoMapper;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.User;

namespace OnlineBabysitterAssistant.Web.Application.Configurations
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			// Domain To Model
			CreateMap<UserRecord, UserModel>();
			CreateMap<ParentRecord, UserModel>();
			CreateMap<BabysitterRecord, UserModel>();
			CreateMap<BabysitterRecord, BabysitterModel>()
				.ForMember(x => x.IsConnectedToParent, opt => opt.Ignore());
			CreateMap<ParentRecord, BabysitterModel>()
				.ForMember(x => x.IsConnectedToParent, opt => opt.Ignore());
			// Model To Domain
			CreateMap<CreateUserModel, UserRecord>();
			CreateMap<LoginUserModel, UserRecord>();
			CreateMap<UpdateUserInfo, UserRecord>();
			CreateMap<CreateUserModel, ParentRecord>();
			CreateMap<CreateUserModel, BabysitterRecord>();
		}
	}
}

