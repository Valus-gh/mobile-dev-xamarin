using System.Collections.ObjectModel;
using MeteoAppSkeleton.Models;

namespace MeteoAppSkeleton.ViewModels
{
    public class MeteoListViewModel : BaseViewModel
    {
        ObservableCollection<Entry> _entries;

        public ObservableCollection<Entry> Entries
        {
            get { return _entries; }
            set
            {
                _entries = value;
                OnPropertyChanged();
            }
        }

        public MeteoListViewModel()
        {
            reload();
        }

        public void reload()
        {

            Entries = new ObservableCollection<Entry>(App.Database.GetAllItems().Result);

        }

    }
}