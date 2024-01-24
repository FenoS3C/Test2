using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Test2
{
    public partial class MainPage : ContentPage
    {
        

        private const string StorageFileName = "countries.json";
       
        public static List<Country> countries = new List<Country>
            {
               
            };
        public MainPage()
        {
            InitializeComponent();
            LoadCountries();
            CountyLV.ItemsSource = null;
        }



        private async void CountyLV_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Country selectedCountry = e.SelectedItem as Country;

                await Navigation.PushAsync(new CountryDetailPage(selectedCountry));

                CountyLV.SelectedItem = null;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCountryPage());


        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            string filePath = Path.Combine(FileSystem.AppDataDirectory, StorageFileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    string serializedData = JsonSerializer.Serialize(countries);
                    await writer.WriteAsync(serializedData);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

       

        private void CountyLV_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Country selectedCountry)
            {
                Transmission.Id = selectedCountry.Id;
            }
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            CountyLV.ItemsSource = null;
            CountyLV.ItemsSource = countries;


        }
        private async Task SaveCountries()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, StorageFileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    string serializedData = JsonSerializer.Serialize(countries);
                    await writer.WriteAsync(serializedData);
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        //await LoadCountries();
        private void LoadCountries()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, StorageFileName);

            try
            {
                if (File.Exists(filePath))
                {
                    string serializedData = File.ReadAllText(filePath);
                    countries.Clear();
                    ObservableCollection<Country> loadedCountries = JsonSerializer.Deserialize<ObservableCollection<Country>>(serializedData);
                    foreach (var country in loadedCountries)
                    {
                        countries.Add(country);
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок при чтении файла
            }
        }
    

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            
            long totalPopulation = 0;
            foreach (var country in countries)
            {
                totalPopulation += country.Population;
            }

            DisplayAlert("Общее население всех стран", $"{totalPopulation}", "OK");
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {

            

            CountyLV.ItemsSource = countries;

        }


    }
}
