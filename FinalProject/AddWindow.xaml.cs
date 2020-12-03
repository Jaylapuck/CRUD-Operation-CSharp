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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private DBHandler DBHandler = DBHandler.Instance;

        public AddWindow()
        {
            InitializeComponent();
        }

        private void AddContact(object sender, RoutedEventArgs e)
        {
            Int32.TryParse(Age.Text, out int AgeConverted);
            DBHandler.InsertingRecord(FirstName.Text, LastName.Text, AgeConverted, Email.Text, PhoneNumber.Text);
            this.Close();
        }
    }
}