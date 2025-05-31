using dentistry.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace dentistry.PageF
{
    public partial class AMSerControl : UserControl
    {
        private Service? _service;
        public string DialogTitle { get; set; } = "Создание услуги";
        public string AddButtonText { get; set; } = "Добавить";

        public AMSerControl()
        {
            InitializeComponent();
            DataContext = this;
            LoadTypes();
        }

        public AMSerControl(Service svc) : this()
        {
            _service = svc;
            DialogTitle = "Редактирование услуги";
            AddButtonText = "Сохранить";
            TitleT.Text = svc.ServicesTitle;
            DescT.Text = svc.ServicesDesc;
            PriceT.Text = svc.ServicesPrice.ToString();
            TypeC.SelectedValue = svc.ServicesTypeId;
        }

        private void LoadTypes()
        {
            using var ctx = new DbDentistryContext();
            var types = ctx.ServicesTypes.ToList();
            TypeC.ItemsSource = types;
            TypeC.DisplayMemberPath = "ServicesTypeTitle";
            TypeC.SelectedValuePath = "ServicesTypeId";
        }

        private void BackB_Click(object sender, RoutedEventArgs e)
            => DialogHost.CloseDialogCommand.Execute(null, this);

        private void AddB_Click(object sender, RoutedEventArgs e)
        {
            if (TypeC.SelectedValue is not int typeId)
            {
                MessageBox.Show("Выберите тип услуги");
                return;
            }

            string result;
            if (_service == null)
                result = Service.AddService(TitleT.Text, DescT.Text, PriceT.Text, typeId);
            else
                result = Service.ModService(_service.ServicesId, TitleT.Text, DescT.Text, PriceT.Text, typeId);

            if (result == "Добавлена" || result == "Изменения сохранены")
            {
                DialogHost.CloseDialogCommand.Execute(result, this);
            }
        }
    }
}
