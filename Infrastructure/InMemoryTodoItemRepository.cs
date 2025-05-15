using Entities;
using UseCases;

namespace Infrastructure;

public class InMemoryTodoItemRepository : ITodoListRepository
{
    private List<TodoItem> _items;

    public InMemoryTodoItemRepository()
    {
        _items = [];
    }

    public void AddTodoItems(TodoItem item)
    {
        _items.Add(item);
    }

    public void Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.ID == id);
        if(item != null) _items.Remove(item);
    }

    public TodoItem GetById(int id)
    {
        return _items.FirstOrDefault(i => i.ID == id);
    }

    public IEnumerable<TodoItem> GetTodoItems()
    {
        return _items;
    }

    public void Update(TodoItem item)
    {
        var existingItem = _items.FirstOrDefault(i => i.ID == item.ID);
        if (existingItem != null)
        {
            existingItem.Text = item.Text;
            existingItem.IsCompleted = item.IsCompleted;
        }
    }
}