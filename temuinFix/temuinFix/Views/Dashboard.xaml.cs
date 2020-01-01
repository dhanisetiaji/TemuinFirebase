using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using temuinFix.ViewModels;
using temuinFix.Services;
using temuinFix.Models;

namespace temuinFix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        WelcomePageVM welcomePageVM;
        FirebaseService firebaseHelper = new FirebaseService();
        public Dashboard(string email)
        {
            InitializeComponent();
            welcomePageVM = new WelcomePageVM(email);
            BindingContext = welcomePageVM;
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToInt32(txtPersonId.Text), txtName.Text, txtDescription.Text, txtAddress.Text);
            txtPersonId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAddress.Text = string.Empty;
            await DisplayAlert("Success", "Data Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.UpdatePerson(Convert.ToInt32(txtPersonId.Text), txtName.Text, txtDescription.Text, txtAddress.Text);
            txtPersonId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtAddress.Text = string.Empty;
            await DisplayAlert("Success", "Data Updated Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.DeletePerson(Convert.ToInt32(txtPersonId.Text));
            await DisplayAlert("Success", "Data Deleted Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
    }
}