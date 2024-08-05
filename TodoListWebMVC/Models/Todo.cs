using System.ComponentModel.DataAnnotations;

namespace TodoListWebMVC.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Created At")]
        [DataType(DataType.Date)]
        public DateTime? CreatedAt { get; set; }
        [Display(Name = "Edited At")]
        [DataType(DataType.Date)]
        public DateTime? EditedAt { get; set; }
    }
}
