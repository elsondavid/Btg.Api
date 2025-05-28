using System.Linq.Expressions;

namespace Btg.Core.Repository;

public interface IGenericRepository<TObject> where TObject : class
{
    TObject Add(TObject t);
    Task<TObject> AddAsync(TObject t);
    int Count();
    Task<int> CountAsync();
    void Delete(params object[] key);
    void Delete(TObject t);
    Task<int> DeleteAsync(params object[] key);
    Task<int> DeleteAsync(TObject t);
    TObject? SingleOrDefault(Expression<Func<TObject, bool>> match);
    IQueryable<TObject> GetAll(Expression<Func<TObject, bool>> match);
    Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match);
    Task<TObject?> SingleOrDefaultAsync(Expression<Func<TObject, bool>> match);
    TObject? Get(params object[] id);
    IQueryable<TObject> GetAll();
    Task<ICollection<TObject>> GetAllAsync();
    Task<TObject?> GetAsync(params object[] id);
    TObject Update(TObject entity);
    bool Any(Expression<Func<TObject, bool>> match);
}