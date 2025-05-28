using Btg.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Btg.Persistence.Repository;

public class GenericRepository<TObject> : IGenericRepository<TObject> where TObject : class
{
    protected DbContextBase _context;

    public DbSet<TObject> DbSet
    {
        get
        {
            return _context.Set<TObject>();
        }
    }

    public GenericRepository(DbContextBase context)
    {
        _context = context;
    }

    public IQueryable<TObject> GetAll()
    {
        return DbSet;
    }

    public IQueryable<TObject> GetAll(Expression<Func<TObject, bool>> match)
    {
        return DbSet.Where(match);
    }

    public async Task<ICollection<TObject>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public TObject? Get(params object[] id)
    {
        return DbSet.Find(id);
    }

    public async Task<TObject?> GetAsync(params object[] id)
    {
        return await DbSet.FindAsync(id);
    }

    public TObject? SingleOrDefault(Expression<Func<TObject, bool>> match)
    {
        return DbSet.SingleOrDefault(match);
    }

    public async Task<TObject?> SingleOrDefaultAsync(Expression<Func<TObject, bool>> match)
    {
        return await DbSet.SingleOrDefaultAsync(match);
    }

    public async Task<ICollection<TObject>> FindAllAsync(Expression<Func<TObject, bool>> match)
    {
        return await DbSet.Where(match).ToListAsync();
    }

    public TObject Add(TObject t)
    {
        DbSet.Add(t);
        _context.SaveChanges();
        return t;
    }

    public async Task<TObject> AddAsync(TObject t)
    {
        DbSet.Add(t);
        await _context.SaveChangesAsync();
        return t;
    }

    public TObject Update(TObject entity)
    {
        var dbEntityEntry = _context.Entry(entity);
        dbEntityEntry.State = EntityState.Modified;

        _context.SaveChanges();

        return entity;
    }

    public void Delete(TObject t)
    {
        DbSet.Remove(t);
        _context.SaveChanges();
    }

    public void Delete(params object[] key)
    {
        var t = this.Get(key);

        if (t != null)
        {
            DbSet.Remove(t);
            _context.SaveChanges();
        }
    }

    public async Task<int> DeleteAsync(TObject t)
    {
        DbSet.Remove(t);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(params object[] key)
    {
        var t = await this.GetAsync(key);
        if (t != null)
        {
            var dbEntityEntry = _context.Entry(t);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(t);
                DbSet.Remove(t);
            }

            return await _context.SaveChangesAsync();
        }
        return 0;
    }

    public int Count()
    {
        return DbSet.Count();
    }

    public async Task<int> CountAsync()
    {
        return await DbSet.CountAsync();
    }

    public bool Any(Expression<Func<TObject, bool>> match)
    {
        return DbSet.Any(match);
    }
}