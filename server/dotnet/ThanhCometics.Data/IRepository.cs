using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ThanhCometics.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task Add(IEnumerable<TEntity> entities);
        TEntity GetById(object id);
        IQueryable<TEntity> GetAll();
        Task Update(TEntity entity);
        Task Update(IEnumerable<TEntity> entities);
        void Remove(int id);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
        void Remove(params TEntity[] entities);
        Task<List<TEntity>> Get(Expression<Func<TEntity, bool>>? filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> oderBy = null,
            int? pageIndex = null,
            int? pageSize = null, params Expression<Func<TEntity, object>>[] includes);
    }
}
