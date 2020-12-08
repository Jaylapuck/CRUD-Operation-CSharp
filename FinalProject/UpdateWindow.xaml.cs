using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            Int32.TryParse(Id.Text, out int id);

            //INPUT VALIDATION

            if (FirstName.Text == "" || LastName.Text == "" || FirstName.Text == "" || Age.Text == "" || Email.Text == "" || PhoneNumber.Text == "")
            {
                MessageBox.Show("All or some fields are empty, FIELDS ARE EMPTY");
            }
            else
            {
                if (!Int32.TryParse(Age.Text, out int AgeConverted))
                {
                    MessageBox.Show("Age is not a valid number", "INVALID  AGE");
                }
                else
                {
                    DBHandler.InsertingRecord(FirstName.Text, LastName.Text, AgeConverted, Email.Text, PhoneNumber.Text);
                    this.Close();
                }
            }
        }
    }
}