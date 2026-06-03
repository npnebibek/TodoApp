using TodoApp.Api.Interfaces;
using TodoApp.Api.Models;
using TodoApp.Api.Services;

namespace TodoApp.Api.Tests;

public class TodoServiceTests
{
    private readonly ITodoService _todoService = new TodoService();

    [Fact]
    public async Task AddTodo_ShouldAddTodoItem_WhenCalled()
    {
        // Arrange
        var newTodoItem = new TodoModel
        {
            Title = "Buy Groceries",
        };

        // Act
        await _todoService.AddTodoAsync(newTodoItem);
        var todoList = await _todoService.GetTodosAsync();

        // Assert
        Assert.Single(todoList);
        Assert.Equal("Buy Groceries", todoList.First().Title);
    }
    
    [Fact]
    public async Task DeleteTodo_ShouldDeleteTodoItem_WhenCalled()
    {
        // Arrange
        var deleteTodoItem = new TodoModel
        {
            Title = "Buy Groceries",
        };
        await _todoService.AddTodoAsync(deleteTodoItem);
        
        // Act
        await _todoService.DeleteTodoAsync(deleteTodoItem.Id);
        var todoList = await _todoService.GetTodosAsync();

        // Assert
        Assert.Empty(todoList);
    }
    
    [Fact]
    public async Task UpdateTodo_ShouldUpdateTodoItem_WhenCalled()
    {
        // Arrange
        var todoItem = new TodoModel
        {
            Title = "Buy Groceries",
            IsCompleted = false
        };
        await _todoService.AddTodoAsync(todoItem);

        // Act
        todoItem.IsCompleted = true;
        await _todoService.UpdateTodoAsync(todoItem);
        
        var todoList = await _todoService.GetTodosAsync();
        var updatedItem = todoList.FirstOrDefault(t => t.Id == todoItem.Id);

        // Assert
        Assert.NotNull(updatedItem);
        Assert.True(updatedItem.IsCompleted);
        Assert.Equal("Buy Groceries", updatedItem.Title);
    }
}