using ToDoListApi1.Models;

namespace ToDoListApi1.Data
{
    public class ToDoRepository
    {
        private List<TodoItem> toDoItems = new List<TodoItem>();
        private int _nextId = 0;
        
        public List<TodoItem> GetTodoItems()
        {
            return toDoItems;
        }

        public TodoItem GetTodoItemById(int id)
        {
            return toDoItems.Where(t => t.Id == id).FirstOrDefault();
        }

        public TodoItem Insert(TodoItem item)
        {
            item.Id = _nextId;
            _nextId++;
            toDoItems.Add(item);
            return item;
        }

        public void Update(TodoItem item)
        {
            toDoItems[item.Id] = item;
        }

        public bool Delete(TodoItem item)
        {
            return toDoItems.Remove(item);
        }
    }
}
