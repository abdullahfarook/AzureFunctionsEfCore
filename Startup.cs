// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Qx.Functions;
using Qx.Services;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Qx.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
            Console.WriteLine(connectionString);
            builder.Services.AddDbContext<TodoContext>(
                options => options.UseSqlServer(connectionString ?? throw new InvalidOperationException("No Db Connection string found")));
            builder.Services.AddScoped<TodoService>();
        }
    }
}
