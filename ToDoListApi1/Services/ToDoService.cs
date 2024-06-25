using ToDoListApi1.Data;
using ToDoListApi1.Models;
using ToDoListApi1.Utils;

namespace ToDoListApi1.Services
{
    public class ToDoService
    {
        private readonly ToDoRepository _toDoRepository;

        public ToDoService(ToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _toDoRepository.GetTodoItems();
        }

        public Result<TodoItem> GetTodoItemById(int id)
        {
            var itemExists = _toDoRepository.GetTodoItemById(id);
            if (itemExists == null) return Result<TodoItem>.Fail($"Item with id {id} does not exist");
            else return Result<TodoItem>.Success(itemExists);
        }

        public TodoItem CreateToDoItem(string title)
        {
            TodoItem item = new TodoItem
            {
                Title = title
            };
            item = _toDoRepository.Insert(item);
            return item;
        }

        public Result<TodoItem> UpdateToDoItem(int id, string description)
        {
            var itemExists = _toDoRepository.GetTodoItemById(id);
            if (itemExists == null) return Result<TodoItem>.Fail($"Item with id {id} does not exist");
            
            itemExists.Description = description;
            _toDoRepository.Update(itemExists);
            return Result<TodoItem>.Success(itemExists);
        }

        public Result<TodoItem> DeleteItem(int id)
        {
            var itemExists = _toDoRepository.GetTodoItemById(id);
            if (itemExists == null) return Result<TodoItem>.Fail($"Item with id {id} does not exist");
            var itemDeleted = _toDoRepository.Delete(itemExists);
            return itemDeleted ? Result<TodoItem>.Success(itemExists) : Result<TodoItem>.Fail("Unexpected error while trying to delete item");
        }
    }
}
