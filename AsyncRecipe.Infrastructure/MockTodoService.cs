namespace AsyncRecipe.Infrastructure;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsyncRecipe.Core.Models;
using AsyncRecipe.Core.Services;

/// <summary>
/// Adapter: Mock implementation of ITodoService.
/// Simulates async loading from a remote API by using Task.Delay.
/// </summary>
public class MockTodoService : ITodoService
{
    /// <summary>
    /// Simulates loading Todos from a remote service with a 2-second delay.
    /// </summary>
    public async Task<List<Todo>> GetTodosAsync(CancellationToken cancellationToken = default)
    {
        // Simulate network latency
        await Task.Delay(2000, cancellationToken);

        // Return mock data
        return new List<Todo>
        {
            new() { Id = 1, Title = "Learn async/await", IsCompleted = false },
            new() { Id = 2, Title = "Create a MAUI app", IsCompleted = false },
            new() { Id = 3, Title = "Understand Tasks", IsCompleted = true },
        };
    }
}
