using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using temuinFix.ViewModels;

namespace temuinFix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginFormPage : ContentPage
    {
        LoginViewModel loginViewModel;
        public LoginFormPage()
        {
            loginViewModel = new LoginViewModel();
            InitializeComponent();
            BindingContext = loginViewModel;
        }
    }
}