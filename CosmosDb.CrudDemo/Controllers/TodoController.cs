using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CosmosDb.CrudDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        //private readonly ITodoRepository _repository;

        private readonly ICosmosRepository<Todo> _repository;

        public TodoController(ICosmosRepository<Todo> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            var todos = await _repository.GetAllAsync();
            return todos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(Guid id)
        {
            var todo = await _repository.GetByIdAsync(id);
            return todo;
        }

        [HttpPost]
        public async Task<ActionResult> AddTodo([FromBody] Todo todo)
        {
            await _repository.AddSingleAsync(todo);
            return Created("", todo);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTodo([FromBody] Todo todo)
        {
            await _repository.UpdateSingleAsync(todo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> AddTodo(Guid id)
        {
            await _repository.DeleteAsync(id);
            return Ok($"item was deleted with id: {id}");
        }
    }
}
