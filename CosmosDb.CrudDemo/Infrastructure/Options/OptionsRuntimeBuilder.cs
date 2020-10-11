//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Options;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CosmosDb.CrudDemo.Infrastructure.Options
//{
//    public class OptionsRuntimeBuilder : IOptionsRuntimeBuilder
//    {
//        List<IBaseOptionBinder> _optionBinders;
//        private readonly IServiceCollection _serviceCollection;
//        private readonly IConfiguration _configuration;

//        public ICollection<IBaseOptionBinder> OptionBinders => _optionBinders;


//        public OptionsRuntimeBuilder(IServiceCollection serviceCollection, IConfiguration configuration)
//        {
//            _optionBinders = new List<IBaseOptionBinder>();
//            _serviceCollection = serviceCollection;
//            _configuration = configuration;
//        }




//        public IOptionsRuntimeBuilder AddOptions<T>(T optionBinder) where T : class, IBaseOptionBinder
//        {
//            _serviceCollection.Configure<T>(_configuration.GetSection(optionBinder.SectionName));
//            _optionBinders.Add(optionBinder);
//            return this;
//        }

//        //public void BindOptionsToContainer()
//        //{
//        //    foreach (IBaseOptionBinder optionBinder in _optionBinders)
//        //    {
//        //        Type optionBinderType = optionBinder.GetType();
//        //        _serviceCollection.Configure<>
//        //    }
//        //}

//    }
//}
