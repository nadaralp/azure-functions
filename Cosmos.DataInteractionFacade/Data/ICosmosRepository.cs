using Cosmos.DataInteractionFacade.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade.Data
{
    public interface ICosmosRepository<T> where T : BaseCosmosEntity
    {
        // Queries
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetCollectionByAsync(Expression<Func<T, bool>> predicateExpression);
        Task<T> GetSingleBy(Expression<Func<T, bool>> predicateExpression);
        Task<T> GetByIdAsync(Guid id);


        // Commands
        Task AddSingleAsync(T entity);

        Task AddBatchAsync(IEnumerable<T> entities);
        Task UpdateSingleAsync(T entity);
        Task UpdateBatchAsync(IEnumerable<T> entities);

        Task<bool> DeleteAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> DeleteBatchAsync(IEnumerable<T> entities);
        Task<bool> DeleteBatchAsync(IEnumerable<Guid> entitiesId);

    }
}
