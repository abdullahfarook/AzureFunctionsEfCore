
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Qx.Services
{
    public class TodoService
    {
        private readonly TodoContext _todoContext;

        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public Task<List<Todo>> GetAll()
        {
            return _todoContext.Todos.ToListAsync();
        }
        public async Task<Todo> Add(Todo item)
        {
             _todoContext.Todos.Add(item);
             await _todoContext.SaveChangesAsync();
             return item;
        }
    }
}
