using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TodoListWebMVC.Models
{
    public class TodoCategoryViewModel
    {
        public List<Todo>? Todoes { get; set; }
        public SelectList? Categories { get; set; }
        public string? TodoCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
