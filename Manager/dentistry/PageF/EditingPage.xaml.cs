using dentistry.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dentistry.PageF
{
    /// <summary>
    /// Логика взаимодействия для EditingPage.xaml
    /// </summary>
    public partial class EditingPage : Page
    {
        public ObservableCollection<Entry> Entries { get; } = new(); 
        public ICollectionView EntriesView { get; private set; }
        private string currentFilter = "";

        public EditingPage()
        {
            InitializeComponent();
            EntriesView = CollectionViewSource.GetDefaultView(Entries);
            EntriesView.Filter = EntryFilter;
            DataContext = this;
            Load();
        }
        private void Load()
        {
            using (var context = new DbDentistryContext())
            {
                Entries.Clear();
                foreach (var entry in context.Entries.ToList())
                {
                    Entries.Add(entry);
                }
                EntriesView.Refresh();
            }
        }

        private bool EntryFilter(object item)
        {
            var entry = item as Entry;
            return currentFilter == "" || entry.EntryStatus == currentFilter;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                currentFilter = button.Tag?.ToString() ?? "";
                EntriesView?.Refresh();
            }
        }

        private async void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is string newStatus)
            {
                var entry = comboBox.DataContext as Entry;
                if (entry == null) return;

                bool isSuccess = await Entry.UpdateEntryStatusAsync(entry.EntryId, newStatus);

                if (isSuccess)
                {
                    Load();
                }
                else
                {
                    MessageBox.Show("Ошибка обновления!");
                }
            }
        }
    }
}
