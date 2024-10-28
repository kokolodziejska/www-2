using Microsoft.AspNetCore.Mvc;
using TodoApp.Models; // Zmiana na odpowiedni� przestrze� nazw
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

public class TodoController : Controller
{
    // Akcja do wy�wietlania listy zada�
    public IActionResult Index()
    {
        // Pobierz list� zada� z sesji, je�li istnieje
        var todoList = HttpContext.Session.GetObjectFromJson<List<TodoItem>>("TodoList") ?? new List<TodoItem>();
        return View(todoList);  // Przeka� list� do widoku
    }

    // Akcja do dodawania nowych zada�
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

    // Akcja do oznaczania zadania jako uko�czone
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
