using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using temuinFix.ViewModels;

namespace temuinFix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        SignUpVM signUpVM;
        public SignUpPage()
        {
            InitializeComponent();
            signUpVM = new SignUpVM();
            //set binding
            BindingContext = signUpVM;
        }
    }
}