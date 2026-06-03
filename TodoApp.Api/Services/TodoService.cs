using TodoApp.Api.Interfaces;
using TodoApp.Api.Models;

namespace TodoApp.Api.Services;

public class TodoService: ITodoService
{
    public Task<List<TodoModel>> GetTodosAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddTodoAsync(TodoModel todoModel)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTodoAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTodoAsync(TodoModel todo)
    {
        throw new NotImplementedException();
    }
}