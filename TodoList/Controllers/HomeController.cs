using System.Diagnostics;
using Entities;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using UseCases;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TodoListManager _listManager;

    public HomeController(TodoListManager listManager ,ILogger<HomeController> logger)
    {
        _listManager = listManager;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var todoItems = _listManager.getTodoItems();
        return View(new TodoListViewModel()
        {
            items = todoItems
        } );
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View("Add");
    }

    [HttpPost]
    public IActionResult Add(Item item)
    {
        _listManager.AddTodoItem(new TodoItem()
        {
            Text = item.Text,
        });
        return RedirectToAction("Index");
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}