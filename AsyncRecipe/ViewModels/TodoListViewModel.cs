namespace AsyncRecipe.ViewModels;

using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AsyncRecipe.Core.Models;
using AsyncRecipe.Core.Services;

/// <summary>
/// ViewModel for the Todo list page.
/// Demonstrates async commands, loading state management, and cancellation.
/// </summary>
public partial class TodoListViewModel : ObservableObject
{
    private readonly ITodoService _todoService;
    private CancellationTokenSource? _cancellationTokenSource;

    public TodoListViewModel(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [ObservableProperty]
    private ObservableCollection<Todo> todos = new();

    [ObservableProperty]
    private bool isBusy;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    /// <summary>
    /// Loads Todos asynchronously. Demonstrates IAsyncRelayCommand and loading state.
    /// </summary>
    [RelayCommand]
    private async Task LoadTodos()
    {
        if (IsBusy) return;

        try
        {
            IsBusy = true;
            ErrorMessage = string.Empty;
            _cancellationTokenSource = new CancellationTokenSource();

            var loadedTodos = await _todoService.GetTodosAsync(_cancellationTokenSource.Token);

            Todos.Clear();
            foreach (var todo in loadedTodos)
            {
                Todos.Add(todo);
            }
        }
        catch (OperationCanceledException)
        {
            ErrorMessage = "Loading was cancelled.";
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Error loading todos: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }

    /// <summary>
    /// Cancels the ongoing async load operation via CancellationToken.
    /// </summary>
    [RelayCommand]
    private void CancelLoad()
    {
        _cancellationTokenSource?.Cancel();
    }

    /// <summary>
    /// Toggles the IsCompleted state of a Todo item.
    /// </summary>
    [RelayCommand]
    private void ToggleTodo(Todo todo)
    {
        var item = Todos.FirstOrDefault(t => t.Id == todo.Id);
        if (item != null)
        {
            item.IsCompleted = !item.IsCompleted;
        }
    }
}
