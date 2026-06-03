using Microsoft.AspNetCore.Mvc;
using TodoApp.Api.Interfaces;
using TodoApp.Api.Models;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController: ControllerBase
{
    private readonly ITodoService _todoService;
    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _todoService.GetTodosAsync());
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(TodoModel todo)
    {
        await _todoService.AddTodoAsync(todo);
        return Ok();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _todoService.DeleteTodoAsync(id);
        return NoContent();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(TodoModel todo)
    {
        await _todoService.UpdateTodoAsync(todo);
        return NoContent();
    }
}