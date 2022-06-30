using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using OnlineBabysitterAssistant.Domain.Entities;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Domain.Models.Child;
using OnlineBabysitterAssistant.Domain.Models.User;
using OnlineBabysitterAssistant.Web.Application.Interfaces;

namespace OnlineBabysitterAssistant.Web.Application.Services
{
	public class BabysitterService : IBabysitterService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public BabysitterService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_mapper = mapper;
			_unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<ChildModel>> GetMyChildren(int userId)
		{
			var children = await _unitOfWork.BabysitterRepository.GetChildren(userId, _mapper.ConfigurationProvider);

			return children;
		}

		public async Task<IEnumerable<ActivityModel>> GetChildActivities(int childId)
        {
			var child = await _unitOfWork.ChildRepository.GetAsync(childId);

			var actitvties = _mapper.Map<IEnumerable<ActivityModel>>(child.ActivityRecords);

			return actitvties;
		}
 
		public async Task<ChildModel> AddActivityToChild(CreateChildActivityModel model)
        {
			var newActivity = _mapper.Map<ActivityRecord>(model);
			var child = await _unitOfWork.ChildRepository.GetAsync(model.ChildId);
			
			//await _unitOfWork.ActivityRepository.AddAsync(newActivity);
			child.ActivityRecords.Add(newActivity);
			await _unitOfWork.SaveAsync();

			//var child = await _unitOfWork.ChildRepository.GetAsync(model.ChildId);

			return _mapper.Map<ChildModel>(child);
			
        }

		public async Task<IEnumerable<UserModel>> GetConnectedParents(int userId)
        {
			var parents = await _unitOfWork.BabysitterRepository.GetParents(userId, _mapper.ConfigurationProvider);

			return parents;
        }

        public async Task<IEnumerable<UserModel>> GetAll(int userId)
        {
			var parent = await _unitOfWork.ParentRepository.GetAsync(userId);
			var connectedBabysitters = parent?.Babysitters.Select(x => x.Id);
			return _unitOfWork.BabysitterRepository.AsQueryable().Where(x => !connectedBabysitters.Contains(x.Id))
												   .ProjectTo<UserModel>(_mapper.ConfigurationProvider)
												   .AsEnumerable();
        }
    }
}

