using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adet_mid_assignment_Perez_Lenie.Models;
using Microsoft.EntityFrameworkCore;

namespace adet_mid_assignment_Perez_Lenie.Infrastructure
{
    public class ToDoContext : DbContext

    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            :base(options)
        {

        }
        public DbSet<TodoList> ToDoList { get; set; }
    }
}
