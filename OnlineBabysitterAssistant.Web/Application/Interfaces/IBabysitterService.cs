using System;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;

namespace OnlineBabysitterAssistant.Web.Application.Interfaces
{
	public interface IBabysitterService
	{
		Task<IEnumerable<ChildModel>> GetMyChildren(int userId);
		Task<ChildModel> AddActivityToChild(CreateChildActivityModel model);
		Task<IEnumerable<UserModel>> GetConnectedParents(int userId);
		Task<IEnumerable<ActivityModel>> GetChildActivities(int childId);
		Task<IEnumerable<UserModel>> GetAll(int userId);
	}
}

