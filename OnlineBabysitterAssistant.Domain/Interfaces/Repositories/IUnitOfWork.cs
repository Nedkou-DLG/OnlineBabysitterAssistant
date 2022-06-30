using System;
namespace OnlineBabysitterAssistant.Domain.Interfaces.Repositories
{
	public interface IUnitOfWork
	{
		IActivityRepository ActivityRepository { get; }
		IBabysitterRepository BabysitterRepository { get; }
		IChildRepository ChildRepository { get; }
		IParentRepository ParentRepository { get; }
		IUserRepository UserRepository { get; }
		void Save();
		Task SaveAsync();
	}
}

