using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmos.DataInteractionFacade.Data;
using CosmosDb.CrudDemo.Models;
using CosmosDb.CrudDemo.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CosmosDb.CrudDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _repository;
        private readonly ILogger<TodoController> _logger;

        //private readonly ICosmosRepository<Todo> _repository;

        public TodoController(ITodoService repository, ILogger<TodoController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IEnumerable<Todo>> GetTodos()
        {
            _logger.LogInformation("GetTodos method invoking...");
            var todos = await _repository.GetAllAsync();
            _logger.LogInformation("GetTodos method done...");
            return todos;
        }


        [HttpGet("doneTasks/{isDone}")]
        public async Task<IEnumerable<Todo>> GetDoneTasks(bool isDone)
        {
            var todos = await _repository.GetAllDoneTasks(isDone);
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
