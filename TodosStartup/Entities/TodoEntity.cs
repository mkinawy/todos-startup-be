using System.Collections.Generic;

namespace TodosStartup.Entities
{
    public class TodoEntity
    {
        public static List<TodoEntity> AllTodos = new List<TodoEntity>
        {
            new TodoEntity {Id = 1, Text = "test 111"},
            new TodoEntity {Id = 2, Text = "test 222"},
            new TodoEntity {Id = 3, Text = "test 333"},
            new TodoEntity {Id = 4, Text = "test 444", Completed = true},
            new TodoEntity {Id = 5, Text = "test 555"},
        };

        public int Id { get; set; }
        public string Text { get; set; }
        public bool Completed { get; set; }
    }
}