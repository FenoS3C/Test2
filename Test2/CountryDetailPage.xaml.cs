namespace Test2;

public partial class CountryDetailPage : ContentPage
{
	public CountryDetailPage(Country selectedCountry)
	{
		InitializeComponent();
        BindingContext = selectedCountry;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditCountryPage());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        MainPage.countries.Remove(MainPage.countries[Transmission.Id - 1]);
        Navigation.PopAsync();

    }
}