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
        public MainWindow()
        {
            InitializeComponent();

            InitializeComponent();

            List<User> userList = new List<User>();

            userList.Add(new User() { FirstName = "Naruto", LastName = "Uzumaki", Age = 16, Email = "hokagelife@gmail.com", PhoneNumber = "450-443-8694" });
            userList.Add(new User() { FirstName = "Garona", LastName = "Lothar", Age = 87, Email = "justWow@gmail.com", PhoneNumber = "450-246-3575" });
            userList.Add(new User() { FirstName = "Getchi", LastName = "Haiper", Age = 16, Email = "lockerRoom@gmail.com", PhoneNumber = "514-235-3232" });
            userList.Add(new User() { FirstName = "Crai", LastName = "Gasem", Age = 42, Email = "craiG@gmail.com", PhoneNumber = "450-443-3992" });
            userList.Add(new User() { FirstName = "Keque", LastName = "Duble-Yu", Age = 68, Email = "kw@gmail.com", PhoneNumber = "450-420-8694" });

            lvDataBinding.ItemsSource = userList;
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

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return "FirstName: " + FirstName + ", LastName " + LastName + " Age " + Age + " Email " + Email + " PhoneNumber " + PhoneNumber;
        }
    }
}