using System;
using OnlineBabysitterAssistant.Domain.Interfaces.Repositories;
using OnlineBabysitterAssistant.Infrastructure.Repositories;

namespace OnlineBabysitterAssistant.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
        protected readonly BabysitterContext context;
        private IActivityRepository activityRepository;
        private IBabysitterRepository babysitterRepository;
        private IChildRepository childRepository;
        private IParentRepository parentRepository;
        private IUserRepository userRepository;

		public UnitOfWork(BabysitterContext context)
		{
            this.context = context;
		}

        public IActivityRepository ActivityRepository
        {
            get
            {
                if(this.ActivityRepository == null)
                {
                    this.activityRepository = new ActivityRepository(context);
                }
                return this.activityRepository;
            }
        }

        public IBabysitterRepository BabysitterRepository
        {
            get
            {
                if(this.babysitterRepository == null)
                {
                    this.babysitterRepository = new BabysitterRepository(context);
                }
                return this.babysitterRepository;
            }
        }

        public IChildRepository ChildRepository
        {
            get
            {
                if(this.childRepository == null)
                {
                    this.childRepository = new ChildRepository(context);
                }
                return this.childRepository;
            }
        }

        public IParentRepository ParentRepository
        {
            get
            {
                if(this.parentRepository == null)
                {
                    this.parentRepository = new ParentRepository(context);
                }
                return this.parentRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if(this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return this.userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

