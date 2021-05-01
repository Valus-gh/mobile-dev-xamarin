using System;
using MeteoAppSkeleton.ViewModels;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MeteoAppSkeleton.Views
{
    public partial class MeteoListPage : ContentPage
    {
        public MeteoListPage()
        {
            InitializeComponent();
            BindingContext = new MeteoListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            //DisplayAlert("Messaggio", "Testo", "OK");

            await ShowDialog();


        }

        async void OnCurrentLocationAdded(object sender, EventArgs e)
        {

            var position = await geolocation.Geolocator.GetCurrentPosition();

            var result = await geolocation.OWMFetcher.GetLocationFromCoordinates(position.Latitude, position.Longitude);

            Models.Entry entry = new Models.Entry
            {
                ID = (string)JObject.Parse(result)["id"],
                Title = (string)JObject.Parse(result)["name"],
                AvgTemp = (double)JObject.Parse(result)["main"]["temp"],
                LowestTemp = (double)JObject.Parse(result)["main"]["temp_min"],
                HighestTemp = (double)JObject.Parse(result)["main"]["temp_max"],

            };

            await App.Database.AddItem(entry);
            ((MeteoListViewModel)BindingContext).reload();
        }

        private async Task ShowDialog()
        {

            //DisplayAlert("Messaggio", "Testo", "OK");
            var newEntryString = await Acr.UserDialogs.UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Name,
                OkText = "Ok",
                Title = "Insert new Entry"
            });

            if (newEntryString.Ok && !string.IsNullOrWhiteSpace(newEntryString.Text))
            {
                var result = await geolocation.OWMFetcher.GetLocationFromName(newEntryString.Text);

                Models.Entry entry = new Models.Entry
                {
                    ID = (string)JObject.Parse(result)["id"],
                    Title = (string)JObject.Parse(result)["name"],
                    AvgTemp = (double)JObject.Parse(result)["main"]["temp"],
                    LowestTemp = (double)JObject.Parse(result)["main"]["temp_min"],
                    HighestTemp = (double)JObject.Parse(result)["main"]["temp_max"],

                };

                await App.Database.AddItem(entry);
                ((MeteoListViewModel)BindingContext).reload();
            }

        }


        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MeteoItemPage()
                {
                    BindingContext = e.SelectedItem as Models.Entry
                });
            }
        }
    }
}