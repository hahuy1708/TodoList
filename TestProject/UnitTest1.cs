using Entities;
using Infrastructure;
using UseCases;

namespace TestProject;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var mockRepository = new InMemoryTodoItemRepository();
        var todoListManager = new TodoListManager(mockRepository);
        
        var todoItem = new TodoItem {ID = 1, Text = "Test Item", IsCompleted = false};
        
        // Act
        todoListManager.AddTodoItem(todoItem);
        todoListManager.MarkCompleted(1);
        
        // Assert
        Assert.True(todoListManager.getTodoItems().First().IsCompleted);
        Assert.Equal("Test Item",todoListManager.getTodoItems().First().Text);
    }
}