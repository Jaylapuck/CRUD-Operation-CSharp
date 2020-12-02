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
        private DBHandler DBHandler = new DBHandler();

        private List<Person> userList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            //find a way to get the ID so that when the window pop ups, the values are already there.
            UpdateWindow update = new UpdateWindow();
            update.Show();
        }

        private void View(object sender, RoutedEventArgs e)
        {
            List<Person> listUsers = DBHandler.ReadAllPersons();
            lvDataBinding.ItemsSource = listUsers;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult areYouSure = MessageBox.Show("Warning!", "Are you sure you wish to delete this record?", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            switch (areYouSure)
            {
                case MessageBoxResult.Yes:
                    //find a way to get the ID and compare it to the database so we can delete it
                    var id = (dynamic)lvDataBinding.SelectedItems[0];
                    DBHandler.DeleteRecord(id);
                    MessageBox.Show("Record deleted");
                    break;

                case MessageBoxResult.No:
                    MessageBox.Show("No Record Added.");
                    break;
            }
        }
    }
}