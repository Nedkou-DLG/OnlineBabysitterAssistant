using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;
using OnlineBabysitterAssistant.Web.Application.Interfaces;

namespace OnlineBabysitterAssistant.Web.Application.Services
{
    public class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ChildModel> AddChild(int userId, CreateChildModel model)
        {

            var record = _mapper.Map<ChildRecord>(model);
            record.ParentId = userId;

            await _unitOfWork.ChildRepository.AddAsync(record);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ChildModel>(record);
        }

        public async Task<IEnumerable<ChildModel>> GetChildren(int userId)
        {
            var children = await _unitOfWork.ChildRepository.GetAllByParent(userId, _mapper.ConfigurationProvider);

            return children;
        }

        public async Task<ChildModel?> GetChild(int userId, int childId)
        {
            var children = await GetChildren(userId);

            return children.FirstOrDefault(x => x.Id == childId);
        }

        public async Task<UserModel> ConnectBabysitter(int userId, int childId)
        {

            var babysitter = await _unitOfWork.BabysitterRepository.GetAsync(childId);
            var parrent = await _unitOfWork.ParentRepository.GetAsync(userId);

            parrent.Babysitters.Add(babysitter);

            await _unitOfWork.SaveAsync();

            return _mapper.Map<UserModel>(parrent);
        }

        public async Task<IEnumerable<UserModel>> GetBabysitters(int userId)
        {
            var babysitters = await _unitOfWork.ParentRepository.GetBabysitters(userId, _mapper.ConfigurationProvider);

            return babysitters;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return _unitOfWork.ParentRepository.AsQueryable()
                                                        .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
                                                        .AsEnumerable();
        }

        public async Task<IEnumerable<BabysitterModel>> GetAllBabysitters(int userId)
        {
            var babysitters = _unitOfWork.BabysitterRepository.AsQueryable()
                                                          .ProjectTo<BabysitterModel>(_mapper.ConfigurationProvider)
                                                          .ToList();
            foreach (var babysitter in babysitters)
            {
                if(babysitter.Parents.Select(x => x.Id).Contains(userId))
                {
                    babysitter.IsConnectedToParent = true;
                }
            }

            return babysitters;
        }

        public async Task<UserModel> DisconnectBabysitter(int userId, int babysitterId)
        {
            var parrent = _unitOfWork.ParentRepository.AsQueryable().Include(x => x.Babysitters).First(x => x.Id == userId);
            if (parrent.Babysitters.Select(x => x.Id).Contains(babysitterId))
            {
                var babysitter = parrent.Babysitters.First(x => x.Id == babysitterId);
                parrent.Babysitters.Remove(babysitter);
                await _unitOfWork.SaveAsync();
            }

            return _mapper.Map<UserModel>(parrent);
        }

        public async Task<ChildModel> AssignBabysitterToChild(AssignBabysitterToChildModel model)
        {
            var babysitter = await _unitOfWork.BabysitterRepository.GetAsync(model.BabysitterId);
            var child = await _unitOfWork.ChildRepository.GetAsync(model.ChildId);

            if(babysitter != null && child != null)
            {
                babysitter?.Children.Add(child);
                child.Babysitter = babysitter;
                await _unitOfWork.SaveAsync();
            }

            return _mapper.Map<ChildModel>(child);

        }

        public async Task<ChildModel> UnassignBabysitterFromChild(int childId)
        {
            var child = await _unitOfWork.ChildRepository.GetAsync(childId);

            child.Babysitter = null;

            await _unitOfWork.SaveAsync();

            return _mapper.Map<ChildModel>(child);
        }

    }
}

