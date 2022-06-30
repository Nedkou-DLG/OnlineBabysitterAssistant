using System;
using AutoMapper;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;

namespace OnlineBabysitterAssistant.Web.Application.Configurations
{
	public class ChildProfile : Profile
	{
		public ChildProfile()
		{
			//Domain to Model
			CreateMap<ChildRecord, ChildModel>();

			//Model to Domain
			CreateMap<CreateChildModel, ChildRecord>();
		}
	}
}

