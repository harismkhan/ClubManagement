using ClubManagement.Backbone;
using ClubManagement.TestApp.Interfaces;
using ClubManagement.Repositories.Interfaces;
using ClubManagement.Contexts;

namespace ClubManagement.Services
{
    public abstract class ManagerServiceBase<TEntity> : IClubManagementApplicationService
        where TEntity : Entity
    {
        protected const string CreateChoice = "1";
        protected const string ReadChoice = "2";
        protected const string UpdateChoice = "3";
        protected const string DeleteChoice = "4";
        protected const string ExitChoice = "5";

        protected readonly string EntityName = typeof(TEntity).Name.ToLower();
        protected readonly string EntityNamePlural = (typeof(TEntity).Name + "s").ToLower();

        private readonly ClubManagementContext context;
        private readonly IBaseRepository<TEntity> repository;

        public ManagerServiceBase(ClubManagementContext context, IBaseRepository<TEntity> repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public async Task RunAsync()
        {

        }
    }
   
}
