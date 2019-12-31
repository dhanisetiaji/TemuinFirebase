using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using temuinFix.ViewModels;
using temuinFix.Services;
using temuinFix.Models;

namespace temuinFix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        FirebaseService firebaseHelper = new FirebaseService();
        public SearchPage()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }
        
    }

}