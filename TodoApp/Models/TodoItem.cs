namespace TodoApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }       // Identyfikator zadania
        public string Task { get; set; }  // Opis zadania
        public bool IsCompleted { get; set; } // Status zadania (czy ukończone)
    }
}
