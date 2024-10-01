using System.ComponentModel.DataAnnotations;
using TodoListWebMVC.Models.ValidationAttributes;

namespace TodoListWebMVC.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Name { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        public string? Category { get; set; }

        [StringLength(120)]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "The Goal to finish date must be today or in the future.")]
        [NotWeekend(ErrorMessage = "Can't be on weekend bro :(")]
        public DateTime? GoalToFinish { get; set; }

        //[Display(Name = "Created At")]
        //[DataType(DataType.Date)]
        //public DateTime? CreatedAt { get; set; }

        //[Display(Name = "Edited At")]
        //[DataType(DataType.Date)]
        //public DateTime? EditedAt { get; set; }

        public bool IsFinished { get; set; }
    }
}
