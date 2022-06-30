
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OnlineBabysitterAssistant.Web.Appplication.Interfaces
{
    public interface IUserService
    {
        AuthenticateUser Authenticate(LoginUserModel model);
        Task<UserRecord> GetById(int userId);
        IEnumerable<UserRecord> GetAll();
        Task<UserModel> RegisterUser(CreateUserModel model);
        Task<UserModel> UpdateUser(int id, UpdateUserInfo profile);

        Task<UserModel> GetUserInfo(int userId);

    }
}
