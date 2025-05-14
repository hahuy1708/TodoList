using Entities;

namespace UseCases;

public class TodoListManager
{
    private readonly ITodoListRepository Repository;

    public TodoListManager(ITodoListRepository _repository)
    {
        this.Repository = _repository;
    }

    public IEnumerable<TodoItem> getTodoItems()
    {
        return Repository.GetTodoItems();
    }

    public void AddTodoItem(TodoItem item)
    {
        Repository.AddTodoItems(item);
    }

    public void MarkCompleted(int id)
    {
        var item = Repository.GetById(id);
        if (item != null)
        {
             item.IsCompleted = true;
             Repository.Update(item);
        }
        
    }

    public void Delete(int id)
    {
        Repository.Delete(id);
    }
    
}