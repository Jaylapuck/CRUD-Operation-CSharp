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

            userList.Add(new User() { FirstName = "Christine", LastName = "Jones", Age = 35, Email = "chrstine@gmail.com", PhoneNumber = "450-443-8694" });
            userList.Add(new User() { FirstName = "Jim", LastName = "Jones", Age = 87, Email = "jimjones@gmail.com", PhoneNumber = "450-246-3575" });
            userList.Add(new User() { FirstName = "Sarah", LastName = "Brown", Age = 16, Email = "sarahbrown@gmail.com", PhoneNumber = "514-235-3232" });
            userList.Add(new User() { FirstName = "Jean", LastName = "Charles", Age = 42, Email = "jean@gmail.com", PhoneNumber = "450-443-8694" });

            lvDataBinding.ItemsSource = userList;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
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