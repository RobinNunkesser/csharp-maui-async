namespace AsyncRecipe.Core.Services;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AsyncRecipe.Core.Models;

/// <summary>
/// Port: abstraction for Todo data loading.
/// Implementations handle async loading from different sources (mock, real API, SQLite, etc.).
/// </summary>
public interface ITodoService
{
    /// <summary>
    /// Loads all Todos asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Allows cancellation of the async operation.</param>
    /// <returns>A list of Todo items.</returns>
    Task<List<Todo>> GetTodosAsync(CancellationToken cancellationToken = default);
}
