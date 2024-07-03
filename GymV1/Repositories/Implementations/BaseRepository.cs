using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using GymV1.Repositories.Interfaces;
using GymV1.ModelsContextDTOs.Context;

namespace GymV1.Repositories.Implementations
{
    public abstract class RepositoryBase<T> : IBaseRepository<T> where T : class
    {
        protected GymContext RepositoryContext { get; set; }

        public RepositoryBase(GymContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            //return this.RepositoryContext.Set<T>().AsNoTracking();
            return this.RepositoryContext.Set<T>().AsNoTrackingWithIdentityResolution();
        }

        public IQueryable<T> FindAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> queryable = this.RepositoryContext.Set<T>();

            if (includes != null)
            {
                queryable = includes(queryable);
            }
            return queryable.AsNoTrackingWithIdentityResolution();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTrackingWithIdentityResolution();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            this.RepositoryContext.SaveChanges();
        }
    }
}
