using Queuer.Application.Common.Mappings;
using Queuer.Domain.Entities;

namespace Queuer.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
