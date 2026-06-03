using TodoApp.Api.Interfaces;
using TodoApp.Api.Models;

namespace TodoApp.Api.Services;

public class TodoService: ITodoService
{
    private readonly List<TodoModel> _todos = new();
    
    public async Task<List<TodoModel>> GetTodosAsync()
    {
        return await Task.FromResult(_todos.ToList());
    }

    public async Task AddTodoAsync(TodoModel todoModel)
    {
        _todos.Add(todoModel);
        await Task.CompletedTask;
    }

    public async Task DeleteTodoAsync(Guid id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }
        await Task.CompletedTask;
    }

    public async Task UpdateTodoAsync(TodoModel todo)
    { 
        var index = _todos.FindIndex(t => t.Id == todo.Id);
        if (index != -1)
        {
            _todos[index] = todo;
        }
        await Task.CompletedTask;
    }
}