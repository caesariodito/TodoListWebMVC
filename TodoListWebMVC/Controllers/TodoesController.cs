using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoListWebMVC.Data;
using TodoListWebMVC.Models;

namespace TodoListWebMVC.Controllers
{
    public class TodoesController : Controller
    {
        private readonly TodoListWebMVCContext _context;

        public TodoesController(TodoListWebMVCContext context)
        {
            _context = context;
        }

        // GET: Todoes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Todo.ToListAsync());
        //}

        public async Task<IActionResult> Index(string todoCategory, string searchString)
        {
            if (_context.Todo == null)
            {
                return Problem("Entity set 'TodoListWebMVCContext.Todo'  is null.");
            }

            // Use LINQ to get list of categories.
            IQueryable<string> categoryQuery = from t in _context.Todo
                                               orderby t.Category
                                               select t.Category;
            var todoes = from t in _context.Todo
                         select t;

            if (!string.IsNullOrEmpty(searchString))
            {
                todoes = todoes.Where(s => s.Name!.ToUpper().Contains(searchString.ToUpper()));
            }

            if (!string.IsNullOrEmpty(todoCategory))
            {
                todoes = todoes.Where(x => x.Category == todoCategory);
            }

            var todoCategoryVM = new TodoCategoryViewModel
            {
                Categories = new SelectList(await categoryQuery.Distinct().ToListAsync()),
                Todoes = await todoes.ToListAsync(),
            };

            return View(todoCategoryVM);
        }

        // GET: Todoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Category,Description,IsFinished")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Category,Description,IsFinished")] Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Todoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo != null)
            {
                _context.Todo.Remove(todo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
