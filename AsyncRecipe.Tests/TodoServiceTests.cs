namespace AsyncRecipe.Tests;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AsyncRecipe.Core.Models;
using AsyncRecipe.Core.Services;
using AsyncRecipe.Infrastructure;

/// <summary>
/// Tests for the MockTodoService demonstrating async test patterns with MSTest.
/// </summary>
[TestClass]
public class TodoServiceTests
{
    [TestMethod]
    [Timeout(5000)]
    public async Task GetTodosAsync_ReturnsThreeTodos()
    {
        // Arrange
        var service = new MockTodoService();

        // Act
        var todos = await service.GetTodosAsync();

        // Assert
        Assert.IsNotNull(todos);
        Assert.AreEqual(3, todos.Count);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetTodosAsync_FirstTodoHasCorrectTitle()
    {
        // Arrange
        var service = new MockTodoService();

        // Act
        var todos = await service.GetTodosAsync();

        // Assert
        Assert.AreEqual("Learn async/await", todos[0].Title);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetTodosAsync_ThirdTodoIsCompleted()
    {
        // Arrange
        var service = new MockTodoService();

        // Act
        var todos = await service.GetTodosAsync();

        // Assert
        Assert.IsTrue(todos[2].IsCompleted);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetTodosAsync_WithCancellation_ThrowsCancelException()
    {
        // Arrange
        var service = new MockTodoService();
        var cts = new CancellationTokenSource();
        cts.CancelAfter(100); // Cancel after 100ms (before 2s delay)

        // Act & Assert
        // Task.Delay with cancellation throws TaskCanceledException (not OperationCanceledException)
        await Assert.ThrowsExceptionAsync<TaskCanceledException>(
            () => service.GetTodosAsync(cts.Token)
        );
    }
}
