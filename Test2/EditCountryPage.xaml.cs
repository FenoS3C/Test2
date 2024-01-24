namespace Test2;

public partial class EditCountryPage : ContentPage
{
	public EditCountryPage()
	{
		InitializeComponent();

        
            nameEntry.Text = MainPage.countries[Transmission.Id - 1].Name;
            populationEntry.Text = Convert.ToString(MainPage.countries[Transmission.Id - 1].Population);
            capitalEntry.Text = MainPage.countries[Transmission.Id - 1].Capital;
            currencyEntry.Text = MainPage.countries[Transmission.Id - 1].Currency;
          
        
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        if (nameEntry.Text != null && long.Parse(populationEntry.Text) > 0 && capitalEntry.Text != null && currencyEntry.Text != null)
        {
            MainPage.countries[Transmission.Id - 1].Name = nameEntry.Text;
            MainPage.countries[Transmission.Id - 1].Population = long.Parse(populationEntry.Text);
            MainPage.countries[Transmission.Id - 1].Capital = capitalEntry.Text;
            MainPage.countries[Transmission.Id - 1].Currency = currencyEntry.Text;
            Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Ошибка", $"Данные введены не корректно", "OK");

        }

    }
}