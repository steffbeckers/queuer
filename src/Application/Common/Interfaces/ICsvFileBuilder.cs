﻿using Queuer.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace Queuer.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
