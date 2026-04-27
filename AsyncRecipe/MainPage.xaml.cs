namespace AsyncRecipe;

using AsyncRecipe.ViewModels;

public partial class MainPage : ContentPage
{
    public MainPage(TodoListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
