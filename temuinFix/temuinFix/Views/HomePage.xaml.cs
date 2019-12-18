using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace temuinFix.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        private Timer timer;
        public List<Banner> Banners { get => GetBanners(); }
        public List<Product> CollectionsList { get => GetCollections(); }
        public List<Product> TrendsList { get => GetTrends(); }

        private List<Banner> GetBanners()
        {
            var bannerList = new List<Banner>();
            bannerList.Add(new Banner { Heading = "BARANG HILANG", Message = "FUJIFILM CAMERA", Caption = "HILANG DI JALAN MALIOBORO", Image = "kamera.png" });
            bannerList.Add(new Banner { Heading = "BARANG TEMUAN", Message = "BLACK HELMET", Caption = "DITEMUKAN DI MESJID", Image = "helm.png" });
            bannerList.Add(new Banner { Heading = "BARANG HILANG", Message = "IPHONE 8", Caption = "DITEMUKAN DI AMIKOM", Image = "hp.png" });
            return bannerList;
        }

        private List<Product> GetCollections()
        {
            var trendList = new List<Product>();
            trendList.Add(new Product { Image = "k_dompet.png", Name = "Dompet Coklat", Location = "Ambarukmo" });
            trendList.Add(new Product { Image = "k_helm.png", Name = "Helm Hitam", Location = "Lippo" });
            trendList.Add(new Product { Image = "k_hp.png", Name = "Iphone 8", Location = "Hartono" });
            trendList.Add(new Product { Image = "k_key.png", Name = "Kunci Rumah", Location = "Jogja City Mall" });
            trendList.Add(new Product { Image = "k_dompet.png", Name = "Dompet Siapa ini", Location = "Sleman City Mall" });
            trendList.Add(new Product { Image = "k_hp.png", Name = "HP ps_store", Location = "Malioboro" });
            return trendList;
        }

        private List<Product> GetTrends()
        {
            var colList = new List<Product>();
            colList.Add(new Product { Image = "k_dompet.png", Name = "Dompet Coklat", Location = "Amikom" });
            colList.Add(new Product { Image = "k_hp.png", Name = "Iphone 8", Location = "Universitas Gadjah Madha" });
            colList.Add(new Product { Image = "k_key.png", Name = "Kunci Rumah", Location = "UKDW" });
            colList.Add(new Product { Image = "k_helm.png", Name = "Helm Hitam", Location = "Bandara Baru" });
            return colList;
        }

        protected override void OnAppearing()
        {
            timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = true, Enabled = true };
            timer.Elapsed += Timer_Elapsed;
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            timer?.Dispose();
            base.OnDisappearing();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if (cvBanners.Position == 2)
                {
                    cvBanners.Position = 0;
                    return;
                }

                cvBanners.Position += 1;
            });
        }
    }
    public class Banner
    {
        public string Heading { get; set; }
        public string Message { get; set; }
        public string Caption { get; set; }
        public string Image { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }
}