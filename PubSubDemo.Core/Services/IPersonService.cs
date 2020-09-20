using PubSubDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDemo.Core.Services
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetAll();

        Task<Person> FirstOrDefault(Expression<Func<Person, bool>> predicateExpression);

        Task<bool> Add(Person person);
    }
}
