using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
        private DBHandler DBHandler = DBHandler.Instance;

        private List<Person> userList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            readAll();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            readAll();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            //find a way to get the ID so that when the window pop ups, the values are already there.
            if (lvDataBinding.SelectedItem != null)
            {
                Person selectedPerson = (Person)lvDataBinding.SelectedItem;

                UpdateWindow update = new UpdateWindow(selectedPerson.FirstName, selectedPerson.LastName, selectedPerson.Age, selectedPerson.Email, selectedPerson.PhoneNumber, selectedPerson.Id);
                update.ShowDialog();
                readAll();
            }
            else
                MessageBox.Show("No contact selected.", "ERROR", MessageBoxButton.OK);
        }

        private void View(object sender, RoutedEventArgs e)
        {
            if (lvDataBinding.SelectedItem != null)
            {
                Person selectedPerson = (Person)lvDataBinding.SelectedItem;

                DetailsWindow view = new DetailsWindow(selectedPerson.FirstName, selectedPerson.LastName, selectedPerson.Age, selectedPerson.Email, selectedPerson.PhoneNumber);
                view.ShowDialog();
            }
            else
                MessageBox.Show("No contact selected.", "ERROR", MessageBoxButton.OK);
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Person person = (Person)lvDataBinding.SelectedItem;

            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this contact?", "Warning", MessageBoxButton.YesNo);

            switch (result)
            {
                case MessageBoxResult.Yes:
                    DBHandler.DeleteRecord(person.Id);
                    MessageBox.Show("Contact has been deleted.");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Contact has not been deleted.");
                    break;
            }


            lvDataBinding.ItemsSource = DBHandler.ReadAllPersons();
        }

        private void readAll()
        {
            lvDataBinding.ItemsSource = DBHandler.ReadAllPersons();
        }

        private void lvDataBinding_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lvDataBinding.SelectedItem != null)
            {
                Person selectedPerson = (Person)lvDataBinding.SelectedItem;

                DetailsWindow view = new DetailsWindow(selectedPerson.FirstName, selectedPerson.LastName, selectedPerson.Age, selectedPerson.Email, selectedPerson.PhoneNumber);
                view.ShowDialog();
            }
            else
                MessageBox.Show("No contact selected.", "ERROR", MessageBoxButton.OK);
        }

        private void Import(object sender, RoutedEventArgs e)
        {
            string[] contactFile = {""};
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == true)
                contactFile = File.ReadAllLines(openFileDialog.FileName);

            DBHandler.DeleteAllRecord();

            foreach (string person in contactFile)
            {
                char[] separators = { ',', ' ' };

                string[] fields = person.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Int32.TryParse(fields[2].ToString(), out int age);

                DBHandler.InsertingRecord(fields[0], fields[1], age, fields[3], fields[4]);
            }

            lvDataBinding.ItemsSource = DBHandler.ReadAllPersons();
        }

        private void Export(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                List<Person> personList = DBHandler.ReadAllPersons();

                string[] personArray = new string[personList.Count];
                for(int i = 0; i <= personList.Count - 1; i++)
                {
                    string[] fields = {personList[i].FirstName, personList[i].LastName, personList[i].Age.ToString(), personList[i].Email, personList[i].PhoneNumber};
                    personArray[i] = string.Join(",", fields);
                }

                File.WriteAllLines(saveFileDialog.FileName, personArray);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {

        }
    }
}