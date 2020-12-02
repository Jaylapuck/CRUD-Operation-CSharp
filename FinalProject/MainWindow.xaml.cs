using System;
using System.Collections.Generic;
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

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DBHandler db = new DBHandler();
        private List<Person> userList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            MessageBoxResult areYouSure = MessageBox.Show("Warning!", "Are you sure you wish to Add this record?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            switch (areYouSure)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Record Added.");
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("No Record Added.");
                    break;
            }
        }

        private void Lookup(object sender, SelectionChangedEventArgs e)
        {
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
        }

        private void View(object sender, RoutedEventArgs e)
        {
            List<Person> listUsers = db.ReadAllPersons();
            lvDataBinding.ItemsSource = listUsers;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult areYouSure = MessageBox.Show("Warning!", "Are you sure you wish to delete this record?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            switch (areYouSure)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Record Deleted.");
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("No Record Deleted.");
                    break;
            }
        }
    }
}