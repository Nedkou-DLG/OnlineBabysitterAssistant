using System;
using AutoMapper;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.Child;

namespace OnlineBabysitterAssistant.Web.Application.Configurations
{
	public class ActivityProfile : Profile
	{
		public ActivityProfile()
		{
			//Domain To Model
			CreateMap<ActivityRecord, ActivityModel>();
				

			//Model to Domain

			CreateMap<CreateChildActivityModel, ActivityRecord>();
		}
	}
}

