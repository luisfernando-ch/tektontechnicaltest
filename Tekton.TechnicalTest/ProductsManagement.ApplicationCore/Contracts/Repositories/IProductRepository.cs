using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ProductsManagement.ApplicationCore.Contracts.Repositories
{
    public interface IProductRepository<TModel> where TModel : class
    {
        #region FirstOrDefault
        TModel? FirstOrDefault(Expression<Func<TModel, bool>> predicate);
        Task<TModel?> FirstOrDefaultAsync(Expression<Func<TModel, bool>> predicate);
        #endregion

        #region Queries
        bool Exists(Expression<Func<TModel, bool>> predicate);
        IQueryable<TModel> Where(Expression<Func<TModel, bool>> predicate);
        TModel? Find(params object?[]? keyValues);
        Task<TModel?> FindAsync(params object?[]? keyValues);
        #endregion

        #region ToX
        IQueryable<TModel> AsQueryable();
        List<TModel> ToList();
        Task<List<TModel>> ToListAsync();
        #endregion

        #region Add
        Task<TModel> AddAsync(TModel model);
        #endregion

        #region Update
        Task<TModel> UpdateAsync(TModel model);
        #endregion
    }
}
