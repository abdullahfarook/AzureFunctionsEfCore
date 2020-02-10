// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Qx.Services;

namespace Qx.Functions
{
    public class TodoFunction
    {
        private readonly TodoService _todoService;

        public TodoFunction(TodoService todoService)
        {
            _todoService = todoService;
        }

        [FunctionName("GetAllTodos")]
        public async Task<IActionResult> GetAllTodos(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var result =  await _todoService.GetAll();
            return new OkObjectResult(result);
        }
        [FunctionName("CreateTodo")]
        public async Task<IActionResult> CreateTodo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Todo req,
            ILogger log)
        {
            var result = await _todoService.Add(req);
            return new OkObjectResult(result);
        }
    }
}
