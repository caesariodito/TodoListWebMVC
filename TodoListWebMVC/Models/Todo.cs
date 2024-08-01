using System.ComponentModel.DataAnnotations;

namespace TodoListWebMVC.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EditedAt { get; set; }
    }
}
