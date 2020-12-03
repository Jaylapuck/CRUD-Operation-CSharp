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
using System.Windows.Shapes;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private DBHandler DBHandler = DBHandler.Instance;

        public UpdateWindow(string firstName, string lastName, int age, string email, string phoneNumber, int id)
        {
            InitializeComponent();
            FirstName.Text = firstName;
            LastName.Text = lastName;
            Age.Text = age.ToString();
            Email.Text = email;
            PhoneNumber.Text = phoneNumber;
            Id.Text = id.ToString();
        }

        private void UpdateContact(object sender, RoutedEventArgs e)
        {
            string firstName = FirstName.Text;
            string lastName = LastName.Text;
            Int32.TryParse(Age.Text, out int age);
            string email = Email.Text;
            string phoneNumber = PhoneNumber.Text;
            Int32.TryParse(Id.Text, out int id);

            DBHandler.UpdateRecord(firstName, lastName, age, email, phoneNumber, id);

            this.Close();
        }
    }
}