using System;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;

namespace OnlineBabysitterAssistant.Web.Application.Interfaces
{
	public interface IParentService
	{
		Task<ChildModel> AddChild(int userId, CreateChildModel model);
		IQueryable<ChildModel> GetChildren(int userId);
		Task<UserModel> ConnectBabysitter(int userId, int childId);
		Task<ChildModel> GetChild(int userId, int childId);
		Task<IEnumerable<UserModel>> GetBabysitters(int userId);
		Task<IEnumerable<UserModel>> GetAll();
		Task<IEnumerable<BabysitterModel>> GetAllBabysitters(int userId);
		Task<UserModel> DisconnectBabysitter(int userId, int babysitterId);
		Task<ChildModel> AssignBabysitterToChild(AssignBabysitterToChildModel model);
		Task<ChildModel> UnassignBabysitterFromChild(int childId);
	}
}

