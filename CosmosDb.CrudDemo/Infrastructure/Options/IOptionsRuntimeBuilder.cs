using System.Collections.Generic;

namespace CosmosDb.CrudDemo.Infrastructure.Options
{
    public interface IOptionsRuntimeBuilder
    {
        ICollection<IBaseOptionBinder> OptionBinders { get; }
        IOptionsRuntimeBuilder AddOptions<T>(T optionBinder) where T : IBaseOptionBinder;
        void BindOptionsToContainer();
    }
}