using dentistry.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace dentistry.PageF
{
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
            using var ctx = new DbDentistryContext();
            Entries.Clear();
            foreach (var entry in ctx.Entries) Entries.Add(entry);
            EntriesView.Refresh();
        }

        private bool EntryFilter(object item)
        {
            var e = item as Entry;
            return currentFilter == "" || e.EntryStatus == currentFilter;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            currentFilter = (sender as Button)?.Tag?.ToString() ?? "";
            EntriesView.Refresh();
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is not ComboBox combo) return;
            if (combo.DataContext is not Entry entry) return;

            string[] items = entry.EntryStatus switch
            {
                "Подтвержден" => new[] { "Подтвержден", "Отменено" },
                "Отменено" => new[] { "Отменено" },
                _ => new[] { "Ожидание", "Подтвержден", "Отменено" },
            };
            combo.ItemsSource = items;
            combo.IsEnabled = entry.EntryStatus != "Отменено";
        }

        private async void ComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            if (sender is ComboBox cb && cb.SelectedItem is string newStatus)
            {
                var entry = cb.DataContext as Entry;
                if (entry == null) return;
                bool ok = await Entry.UpdateEntryStatusAsync(entry.EntryId, newStatus);
                if (ok) Load(); else MessageBox.Show("Ошибка обновления!");
            }
        }
    }
}
