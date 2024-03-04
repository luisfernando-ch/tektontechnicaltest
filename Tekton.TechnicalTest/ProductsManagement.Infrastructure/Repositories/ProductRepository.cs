using Microsoft.EntityFrameworkCore;
using ProductsManagement.ApplicationCore.Contracts.Repositories;
using ProductsManagement.Persistence.SqlServer.Contexts;
using System.Linq.Expressions;

namespace ProductsManagement.Infrastructure.Repositories
{
    public class ProductRepository<TModel> : IProductRepository<TModel> where TModel : class
    {
        protected readonly ProductsDatabaseContext Context;
        protected readonly DbSet<TModel> DbSet;
        public ProductRepository(ProductsDatabaseContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<TModel>();
        }

        #region FirstOrDefault
        public TModel? FirstOrDefault(Expression<Func<TModel, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }
        public async Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await DbSet.FirstOrDefaultAsync(predicate);
        }   
        #endregion

        #region Queries
        public bool Exists(Expression<Func<TModel, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }
        public IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }
        public TModel? Find(params object?[]? keyValues)
        {
            return DbSet.Find(keyValues);
        }
        public async Task<TModel?> FindAsync(params object?[]? keyValues)
        {
            return await DbSet.FindAsync(keyValues);
        }
        #endregion

        #region ToX
        public IQueryable<TModel> AsQueryable()
        {
            return DbSet.AsQueryable();
        }
        public List<TModel> ToList()
        {
            return DbSet.ToList();
        }
        public async Task<List<TModel>> ToListAsync()
        {
            return await DbSet.ToListAsync();
        }
        #endregion

        #region Add
        public async Task<TModel> AddAsync(TModel model)
        {
            DbSet.Add(model);
            await Context.SaveChangesAsync();
            return model;
        }
        #endregion

        #region Update
        public async Task<TModel> UpdateAsync(TModel model)
        {
            DbSet.Update(model);
            await Context.SaveChangesAsync();
            return model;
        }
        #endregion

    }
}
