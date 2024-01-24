using System.Diagnostics.Metrics;
using System.Windows.Input;

namespace Test2;

public partial class AddCountryPage : ContentPage
{
   

    public AddCountryPage()
	{
		InitializeComponent();
       
    }
    

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (nameEntry.Text != null && long.Parse(populationEntry.Text) > 0 && capitalEntry.Text != null && currencyEntry.Text != null)
        {
            var newCountry = new Country
            {
                Id = MainPage.countries.Count + 1,
                Name = nameEntry.Text,
                Population = long.Parse(populationEntry.Text),
                Capital = capitalEntry.Text,
                Currency = currencyEntry.Text
            };
            MainPage.countries.Add(newCountry);

           
            Navigation.PopAsync();
        }
        else
        {
            DisplayAlert("Ошибка", $"Данные введены не корректно", "OK");

        }

    }
}