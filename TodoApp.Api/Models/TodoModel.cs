namespace TodoApp.Api.Models;

public class TodoModel
{
    public Guid Id { get; set; } = new();
    
    public string Title { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; } = false;
}