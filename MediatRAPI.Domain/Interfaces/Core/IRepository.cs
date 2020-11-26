using System.Threading.Tasks;

namespace MediatRAPI.Domain.Interfaces.Core
{
    public interface IRepository<TEntity> where TEntity : class 
    {
        public Task Create(TEntity entity);
        public Task Update(int id, TEntity entity);
        public Task Delete(int id, TEntity entity);
        public Task<TEntity> GetById(int id);
        public void SaveChanges();
    }
}
