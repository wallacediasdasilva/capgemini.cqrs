using MediatRAPI.Domain.Interfaces.Core;
using MediatRAPI.Persistence.EFCore.Context;
using System.Threading.Tasks;

namespace MediatRAPI.Persistence.EFCore.Repository.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MediatRContext _mediatRContext;

        public Repository(MediatRContext mediatRContext)
        {
            _mediatRContext = mediatRContext;
        }

        public async Task Create(TEntity entity)
        {
            await _mediatRContext.AddAsync(entity);
            SaveChanges();
        }

        public async Task Delete(int id, TEntity entity)
        {
            _mediatRContext.Remove(entity);
            
            SaveChanges();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Task.FromResult(_mediatRContext.Set<TEntity>().Find(id));
        }

        public async Task Update(int id, TEntity entity)
        {
            _mediatRContext.Update(entity);

            SaveChanges();
        }

        public void SaveChanges()
        {
            _mediatRContext.SaveChangesByTeam();
        }
    }
}
