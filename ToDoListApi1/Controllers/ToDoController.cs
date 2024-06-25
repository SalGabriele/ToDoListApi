using Microsoft.AspNetCore.Mvc;
using ToDoListApi1.Data;
using ToDoListApi1.Models;
using ToDoListApi1.Services;

namespace ToDoListApi1.Controllers
{
    [ApiController]
    [Route("todos")]
    public class ToDoController: ControllerBase
    {
        private readonly ToDoService _toDoService;

        public ToDoController(ToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ActionResult<IEnumerator<TodoItem>> GetTodoItems()
        {
            return Ok(_toDoService.GetTodoItems());
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(int id)
        {
            var result = _toDoService.GetTodoItemById(id);

            if (result.IsSuccess) return Ok(result.Data);
            else return BadRequest(result.Error);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(string title)
        {
            var result = _toDoService.CreateToDoItem(title);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<TodoItem> Update(int id, string description)
        {
            var result = _toDoService.UpdateToDoItem(id, description);

            if (result.IsSuccess) return Ok(result.Data);
            else return BadRequest(result.Error);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _toDoService.DeleteItem(id);

            if (result.IsSuccess) return Ok();
            else return BadRequest(result.Error);
        }

    }
}
