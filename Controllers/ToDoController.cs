using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using adet_mid_assignment_Perez_Lenie.Infrastructure;
using adet_mid_assignment_Perez_Lenie.Models;

namespace adet_mid_assignment_Perez_Lenie.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;
        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }

        //GET /
        public async Task<ActionResult> Index()

        {
            IQueryable<TodoList> items = from i in context.ToDoList orderby i.Id select i;
            List<TodoList> todoList = await items.ToListAsync();

            return View(todoList);
        }

        //GET /todo/create
        public IActionResult Create() => View();

        //POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "Task has been added!";

                return RedirectToAction("Index");

            }

            return View(item);

        }


            //GET /todo/edit
            public async Task<ActionResult> Edit(int Id)

            {
                TodoList item = await context.ToDoList.FindAsync(Id);

                if(item == null)
                {
                    return NotFound();
                }

                return View(item);
            }


        //POST /todo/edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TodoList item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "Task has been updated!";

                return RedirectToAction("Index");

            }

            return View(item);

        }

        //GET /todo/delete
        public async Task<ActionResult> Delete(int Id)

        {
            TodoList item = await context.ToDoList.FindAsync(Id);

            if (item == null)
            {
                TempData["Ero"] = "Task does not exist!";
            }

            else
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();

                TempData["Success"] = "Task has been deleted!";
            }

            return RedirectToAction("Index");
        }


    }




}
