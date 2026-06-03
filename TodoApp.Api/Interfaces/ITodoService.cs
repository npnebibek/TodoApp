using TodoApp.Api.Models;

namespace TodoApp.Api.Interfaces;

public interface ITodoService
{
    Task<List<TodoModel>> GetTodosAsync();

    Task AddTodoAsync(TodoModel todoModel);

    Task DeleteTodoAsync(Guid id);
    
    Task UpdateTodoAsync(TodoModel todo);
}