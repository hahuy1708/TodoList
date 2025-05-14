using Entities;

namespace UseCases;

public interface ITodoListRepository
{
    IEnumerable<TodoItem> GetTodoItems();
    void AddTodoItems(TodoItem item);
    TodoItem GetById(int id);
    void Update(TodoItem? item);
    void Delete(int id);
}