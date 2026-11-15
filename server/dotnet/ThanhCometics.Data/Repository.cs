using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ThanhCometics.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ThanhCometicsDBContext _dbContext;
        public DbSet<TEntity> Entities { get; set; }
        public Repository(ThanhCometicsDBContext dbContext)
        {
            _dbContext = dbContext;
            Entities = _dbContext.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Add(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            Entities.AddRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities;
        }

        public async Task Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities)); 
            Entities.UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public void Remove(int id)
        {
            var entity = Entities.Find(id);// impossible cause hidden bug :>
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            Entities.Remove(entity);
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            Entities.RemoveRange(entities);
        }

        public void Remove(params TEntity[] entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            Entities.RemoveRange(entities);
        }

        public Task<List<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> oderBy = null, int? pageIndex = null, int? pageSize = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Entities;
            if(filter != null) query = query.Where(filter);
            foreach (var includesProperty in includes)
            {
                if(includesProperty.Body is MemberExpression memberExpression)
                {
                    query = query.Include(memberExpression.Member.Name);
                }
            }
            if(oderBy != null) query = oderBy(query);
            //implementing pagination
            if(pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0 ;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10 ;

                query = query.Skip(validPageIndex*validPageSize).Take(validPageSize);
            }

            return query.ToListAsync();
        } 
    }
}
