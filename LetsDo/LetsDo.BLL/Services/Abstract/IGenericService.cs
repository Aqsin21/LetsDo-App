
using System.Linq.Expressions;
namespace LetsDo.BLL.Services.Abstract
{
    public interface IGenericService<T> where T : class
    {
        // Tüm listeyi getir (include ve filter ile)
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            params Expression<Func<T, object>>[] includes);

        // Tek bir kayıt getir (navigation property'leri dahil etmek için)
        Task<T?> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includes);

        // Var mı yok mu kontrolü (örnek: email zaten kayıtlı mı?)
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        // CRUD
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
