using Microsoft.AspNetCore.Mvc;
using TodoApp.Models; // Zmiana na odpowiedni¹ przestrzeñ nazw
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

public class TodoController : Controller
{
    // Akcja do wyœwietlania listy zadañ
    public IActionResult Index()
    {
        // Pobierz listê zadañ z sesji, jeœli istnieje
        var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>("TodoList") ?? new List<TodoItem>();
        return View(todoList);  // Przeka¿ listê do widoku
    }

    // Akcja do dodawania nowych zadañ
    [HttpPost]
    public IActionResult Add(string task)
    {
        var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>("TodoList") ?? new List<TodoItem>();
        var newItem = new TodoItem
        {
            Id = todoList.Count + 1,  // Proste generowanie Id
            Task = task,
            IsCompleted = false
        };
        todoList.Add(newItem);
        HttpContext.Session.SetObjectAsJson("TodoList", todoList);

        return Json(newItem);  // Zwracamy nowy element w formacie JSON
    }

    // Akcja do oznaczania zadania jako ukoñczone
    [HttpPost]
    public IActionResult Complete(int id)
    {
        var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>("TodoList");
        if (todoList != null)
        {
            var item = todoList.Find(t => t.Id == id);
            if (item != null)
            {
                item.IsCompleted = true;
                HttpContext.Session.SetObjectAsJson("TodoList", todoList);
                return Json(item);
            }
        }
        return NotFound();
    }

    // Akcja do usuwania zadania
    [HttpPost]
    public IActionResult Remove(int id)
    {
        var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>("TodoList");
        if (todoList != null)
        {
            var item = todoList.Find(t => t.Id == id);
            if (item != null)
            {
                todoList.Remove(item);
                HttpContext.Session.SetObjectAsJson("TodoList", todoList);
                return Json(item);
            }
        }
        return NotFound();
    }
}
