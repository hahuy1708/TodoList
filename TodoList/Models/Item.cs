namespace TodoList.Models;

public class Item
{
    public int ID  { get; set; }
    public required string Text { get; set; }
    public bool IsCompleted { get; set; }
}