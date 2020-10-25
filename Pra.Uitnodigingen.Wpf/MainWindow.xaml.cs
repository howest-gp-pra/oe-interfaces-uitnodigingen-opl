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
using Pra.Uitnodigingen.Core.Entities;
using Pra.Uitnodigingen.Core.Enumerations;
using Pra.Uitnodigingen.Core.Interfaces;
using Pra.Uitnodigingen.Core.Services;

namespace Pra.Uitnodigingen.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Contacts contacts;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contacts = new Contacts();
            PopulateFilter();
            PopulateContacts();
        }
        private void PopulateFilter()
        {
            cmbFilter.Items.Clear();
            cmbFilter.Items.Add("Alle contacten");
            cmbFilter.Items.Add("Familie");
            cmbFilter.Items.Add("Vrienden");
            cmbFilter.Items.Add("Klanten");
            cmbFilter.Items.Add("Contacten voor verjaardagsuitnodiging");
            cmbFilter.Items.Add("Contacten voor bedrijfsuitnodiging");
            cmbFilter.SelectedIndex = 0;
        }
        private void PopulateContacts()
        {
            lstContacts.Items.Clear();
            tbkInfo.Text = "";
            if(cmbFilter.SelectedIndex == 0) // = alle contacten
            {
                foreach(Person person in contacts.MyContacts)
                {
                    lstContacts.Items.Add(person);
                }
            }
            else if (cmbFilter.SelectedIndex == 1) // enkel familie
            {
                foreach (Person person in contacts.MyContacts)
                {
                    if(person is Family)
                        lstContacts.Items.Add(person);
                }
            }
            else if (cmbFilter.SelectedIndex == 2) // enkel vrienden
            {
                foreach (Person person in contacts.MyContacts)
                {
                    if (person is Friend)
                        lstContacts.Items.Add(person);
                }
            }
            else if (cmbFilter.SelectedIndex == 3) // enkel klanten
            {
                foreach (Person person in contacts.MyContacts)
                {
                    if (person is Customer)
                        lstContacts.Items.Add(person);
                }
            }
            else if (cmbFilter.SelectedIndex == 4) // contacten die een verjaardagsuitnodiging zullen ontvangen
            {
                foreach(Person person in contacts.MyContacts)
                {
                    if(person is IBirthdayInvitation)
                        lstContacts.Items.Add(person);
                }
            }
            else if (cmbFilter.SelectedIndex == 5) // contacten die een bedrijfsuitnodiging zullen ontvangen
            {
                foreach (Person person in contacts.MyContacts)
                {
                    if (person is IBusinessInvitation)
                        lstContacts.Items.Add(person);
                }
            }
        }

        private void lstContacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstContacts.SelectedItem == null) return;

            tbkInfo.Text = ((Person)lstContacts.SelectedItem).ShowInfo();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateContacts();
        }

        private void btnBirthday_Click(object sender, RoutedEventArgs e)
        {
            tbkInvitations.Text = "";
            foreach (Person person in contacts.MyContacts)
            {
                if (person is IBirthdayInvitation)
                {
                    tbkInvitations.Text += ((IBirthdayInvitation)person).MakeInvitation("hier komt de uitnodiging voor mijn verjaardag");
                    tbkInvitations.Text += $"==============================================\n";
                }
            }
        }

        private void btnExhibition_Click(object sender, RoutedEventArgs e)
        {
            tbkInvitations.Text = "";
            foreach (Person person in contacts.MyContacts)
            {
                if (person is IBusinessInvitation)
                {
                    tbkInvitations.Text += ((IBusinessInvitation)person).MakeInvitation("hier komt de uitnodiging voor onze tentoonstelling");
                    tbkInvitations.Text += $"==============================================\n";
                }
            }
        }
    }
}
