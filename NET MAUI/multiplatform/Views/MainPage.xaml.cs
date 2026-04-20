using ProjectManager.ViewModels;

namespace ProjectManager.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnSelected(object sender, SelectionChangedEventArgs e)
    {
        var movie = e.CurrentSelection.FirstOrDefault() as MovieViewModel;
        if (movie == null) return;

        await Navigation.PushAsync(new MovieDetailsPage(movie));
    }
}