using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Domain.Models.User;
using OnlineBabysitterAssistant.Web.Appplication.Configurations.Helpers;
using OnlineBabysitterAssistant.Web.Appplication.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using OnlineBabysitterAssistant.Domain.Exceptions.Custom;

namespace OnlineBabysitterAssistant.Web.Appplication.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IJwtUtils _jwtUtils;

        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork,
            IJwtUtils jwtUtils, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }
        public AuthenticateUser Authenticate(LoginUserModel model)
        {
            var user = _unitOfWork.UserRepository.AsEnumerable().FirstOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) 
                throw new UserNotFoundException(CustomExceptionMessagesConstants.UserLoginNotFound);

            // authentication successful so generate jwt token
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateUser(user, jwtToken);
        }

        public async Task<UserRecord> GetById(int userId)
        {
            return await _unitOfWork.UserRepository.GetAsync(userId);
            
        }

        public IEnumerable<UserRecord> GetAll()
        {
            return _unitOfWork.UserRepository.AsEnumerable();
        }

        public async Task<UserModel> RegisterUser(CreateUserModel model)
        {
            if (model.Type == UserType.PARENT)
            {
                var record = _mapper.Map<ParentRecord>(model);
                await _unitOfWork.ParentRepository.AddAsync(record);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<UserModel>(record);
            }
            else
            {
                var record = _mapper.Map<BabysitterRecord>(model);
                await _unitOfWork.BabysitterRepository.AddAsync(record);
                await _unitOfWork.SaveAsync();
                return _mapper.Map<UserModel>(record);
            }
        }

        public async Task<UserModel> GetUserInfo(int userId)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(userId);
            
            if (user == null)
                throw new UserNotFoundException(CustomExceptionMessagesConstants.UserNotFound);
            
            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> UpdateUser(int id, UpdateUserInfo profile)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            _mapper.Map<UpdateUserInfo, UserRecord>(profile, user);

            _unitOfWork.UserRepository.Update(user);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserModel>(user);
        }
    }
}
