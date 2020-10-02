using Cosmos.DataInteractionFacade.Data;
using Cosmos.DataInteractionFacade.Entities;
using System.Threading.Tasks;

namespace Cosmos.DataInteractionFacade.Builder
{
    public interface ICosmosRepositoryBuilder
    {
        Task<GenericCosmosRepository<T>> GetCosmosGenericRepository<T>(string databaseName, string containerName) where T : BaseCosmosEntity;
        Task<TRepository> GetCosmosRepository<TRepository, TEntity>(string databaseName, string containerName)
            where TRepository : GenericCosmosRepository<TEntity>
            where TEntity : BaseCosmosEntity;
    }
}