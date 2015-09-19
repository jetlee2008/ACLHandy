using ACLHandy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ACLHandy
{
    /// <summary>
    /// Interaction logic for RecordForm.xaml
    /// </summary>
    public partial class RecordForm : Window
    {
        public RecordListViewModel ViewModel { get; set; }
        public RecordForm()
        {
            ViewModel = new RecordListViewModel();
            this.DataContext = ViewModel;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
