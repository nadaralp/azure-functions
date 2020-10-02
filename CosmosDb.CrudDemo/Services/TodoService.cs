using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Services
{
    public class TodoService : ITodoService
    {
        private readonly ICosmosRepository<Todo> _repository;

        public TodoService(ICosmosRepository<Todo> repository)
        {
            _repository = repository;
        }


        public async Task AddTodoItem(Todo todo)
        {
            await _repository.AddSingleAsync(todo);
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _repository.GetAllAsync();
        }
    }
}
