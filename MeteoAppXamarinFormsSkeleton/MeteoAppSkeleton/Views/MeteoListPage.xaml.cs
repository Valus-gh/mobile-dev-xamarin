using System;
using MeteoAppSkeleton.ViewModels;
using Xamarin.Forms;
using Acr.UserDialogs;
using System.Threading.Tasks;

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

        void OnItemAdded(object sender, EventArgs e)
        {
            //DisplayAlert("Messaggio", "Testo", "OK");
            Task.Run(showDialog);
        }

        private async Task showDialog()
        {

            //DisplayAlert("Messaggio", "Testo", "OK");
            var newEntryString = await Acr.UserDialogs.UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Name,
                OkText = "Ok",
                Title = "Insert new Entry"
            });

            if (newEntryString.Ok && !string.IsNullOrWhiteSpace(newEntryString.Text)) ;
            //do add newEntryString.Text

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