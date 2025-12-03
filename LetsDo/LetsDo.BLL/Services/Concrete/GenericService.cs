using LetsDo.BLL.Services.Abstract;
using LetsDo.DAL.DataContext;
using LetsDo.DAL.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace LetsDo.BLL.Services.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            return await _repository.SaveChangesAsync() > 0;
        }

        // Basit kullanım (çoğu zaman bu yeter)
        public async Task<IEnumerable<T>> GetAllAsync()
            => await _repository.GetAllAsync();

        // Gelişmiş kullanım → interface'teki zorunlu imza
        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[] includes)
            => await _repository.GetAllAsync(filter, includes);

        public async Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes)
            => await _repository.GetByIdAsync(id, includes);

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _repository.AnyAsync(predicate);
    }

}