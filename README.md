# AsyncRecipe — Async/Await in MAUI (Agent-Generated)

## Overview

This is a **modernized, agent-generated example** demonstrating `async`/`await` patterns in **.NET MAUI** for advanced students.

The example shows:
- **Async Data Loading** from a simulated remote service with a 2-second delay
- **Loading State Management** using `IsBusy` property
- **Error Handling** for async operations and cancellation
- **MVVM Architecture** with `CommunityToolkit.Mvvm`
- **Dependency Injection** via `MauiProgram.cs`
- **Unit Tests** with MSTest covering async patterns

## Architecture

### Separation of Concerns

```
AsyncRecipe.Core/           ← Domain models (Todo) and service interfaces (ITodoService)
AsyncRecipe.Infrastructure/ ← MockTodoService adapter (simulates remote API)
AsyncRecipe/                ← MAUI app, UI layer, composition root (MauiProgram.cs)
AsyncRecipe.Tests/          ← MSTest unit tests for Core and async patterns
```

### Key Concepts

#### 1. **Core Layer** (`AsyncRecipe.Core`)
- `Models/Todo.cs` — Domain model with Id, Title, IsCompleted
- `Services/ITodoService.cs` — Port: async interface for data loading

#### 2. **Infrastructure Layer** (`AsyncRecipe.Infrastructure`)
- `MockTodoService.cs` — Adapter: implements `ITodoService`, simulates async loading with `Task.Delay(2000)`

#### 3. **MAUI App Layer** (`AsyncRecipe`)
- `MainPage.xaml` + `MainPage.xaml.cs` — MVVM UI (no business logic in code-behind)
- `ViewModels/TodoListViewModel.cs` — MVVM ViewModel with `IAsyncRelayCommand` for async operations
- `MauiProgram.cs` — Dependency Injection setup (ITodoService, ViewModels, Pages)

#### 4. **Tests** (`AsyncRecipe.Tests`)
- `TodoServiceTests.cs` — Async service tests with `[Timeout]` attribute
- `TodoListViewModelTests.cs` — ViewModel tests demonstrating loading state, error handling, and async command patterns

## Running the Example

### Prerequisites
- .NET 8.0 SDK installed
- MAUI workload: `dotnet workload install maui`
- macOS with Xcode (for maccatalyst/iOS)

### Build & Run

#### Android (Recommended)
```bash
dotnet build -f net8.0-android
dotnet run -f net8.0-android
```

#### maccatalyst (with Xcode version mismatch workaround)
```bash
dotnet build -f net8.0-maccatalyst
dotnet run -f net8.0-maccatalyst
```

**Note:** The `.csproj` includes `<ValidateXcodeVersion>false</ValidateXcodeVersion>` to work around MAUI/Xcode version conflicts on macOS.

### Run Tests
```bash
cd AsyncRecipe.Tests
dotnet test
```

## Learning Points

### 1. Async/Await Pattern
- `Task<T>` return types for async operations
- `await` keyword pausing execution until the Task completes
- Non-blocking UI during async loading (LoadTodos command)

### 2. Async Commands (`IAsyncRelayCommand`)
- `[RelayCommand]` attribute from `CommunityToolkit.Mvvm`
- Automatic command binding in MVVM
- Built-in execution guards (e.g., `IsRunning`)

### 3. Cancellation Tokens
- `CancellationToken` parameter for graceful cancellation
- `CancelLoad()` command demonstrates `cancellationTokenSource.Cancel()`
- Tests verify cancellation behavior with `[Timeout]`

### 4. Error Handling
- Try/catch around async operations
- `ErrorMessage` property displayed in UI
- Distinction between `OperationCanceledException` and general exceptions

### 5. Loading State
- `IsBusy` property toggled during async operations (true → false)
- UI binds to `IsBusy` for activity indicator visibility
- Prevents duplicate commands while loading

### 6. Testing Async Code
- `async Task` test methods with MSTest
- `[Timeout]` attribute for long-running tests
- `Assert.ThrowsExceptionAsync<>()` for exception testing
- Mocked service allows predictable, fast tests

## Comparison to Manual Version

| Aspect | Manual (Old) | Agent-Generated (New) |
|--------|------|------|
| **Code-Behind** | Event handlers in XAML | No code-behind (MVVM) |
| **Service Layer** | Inline in ViewModel | Separate Core + Infrastructure |
| **DI Container** | Manual instantiation | `MauiProgram.cs` IServiceCollection |
| **MVVM Toolkit** | — | CommunityToolkit.Mvvm ([ObservableProperty], [RelayCommand]) |
| **Test Framework** | NUnit | MSTest |
| **Test Coverage** | Single simple test | 7 comprehensive async tests |
| **Async Scenario** | `Task.Delay(1000)` | 2-second mock API load with cancellation |
| **Error Handling** | — | Try/catch, ErrorMessage binding |

The agent-generated version reflects **how async/await is used in enterprise code**: proper architecture, testable dependencies, MVVM patterns, and comprehensive async/cancellation handling.

## Files

```
AsyncRecipe.sln
├── AsyncRecipe/
│   ├── MainPage.xaml           ← MVVM UI
│   ├── MainPage.xaml.cs        ← Code-behind (only lifecycle)
│   ├── ViewModels/
│   │   └── TodoListViewModel.cs ← Async commands, state, IAsyncRelayCommand
│   ├── MauiProgram.cs          ← DI setup
│   ├── App.xaml, AppShell.xaml ← Navigation
│   └── AsyncRecipe.csproj      ← Refs Core, Infrastructure, CommunityToolkit.Mvvm
├── AsyncRecipe.Core/
│   ├── Models/
│   │   └── Todo.cs             ← Domain model
│   ├── Services/
│   │   └── ITodoService.cs     ← Port (abstraction)
│   └── AsyncRecipe.Core.csproj ← net8.0, no UI deps
├── AsyncRecipe.Infrastructure/
│   ├── MockTodoService.cs      ← Adapter (2-sec delay simulation)
│   └── AsyncRecipe.Infrastructure.csproj ← Refs Core
└── AsyncRecipe.Tests/
    ├── TodoServiceTests.cs      ← Async service tests
    ├── TodoListViewModelTests.cs ← Async command + state tests
    └── AsyncRecipe.Tests.csproj  ← MSTest, refs Core + Infrastructure
```

## References

- [Microsoft Docs: Async/Await](https://learn.microsoft.com/en-us/archive/msdn-magazine/2013/march/async-await-best-practices-in-asynchronous-programming)
- [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet/wiki/MVVM-Toolkit-Introduction)
- [MAUI Dependency Injection](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/dependency-injection)
- [Testing Async Code](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#async)

---

**Generated:** 2026-04-27  
**Framework:** .NET 8.0, MAUI 10.0  
**Status:** Ready for teaching
