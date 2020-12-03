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
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(string firstName, string lastName, int age, string email, string phoneNumber)
        {
            InitializeComponent();
            FirstName.Text = firstName;
            LastName.Text = lastName;
            Age.Text = age.ToString();
            Email.Text = email;
            PhoneNumber.Text = phoneNumber;
        }
    }
}
