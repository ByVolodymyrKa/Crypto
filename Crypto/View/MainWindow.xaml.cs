using Crypto.ViewModel;
using System.Threading.Tasks;
using System.Windows;

namespace Crypto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationViewModel ApplicationViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ApplicationViewModel = (ApplicationViewModel)DataContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            StartAndRefresh();
            AllCoins();
        }

        private async void StartAndRefresh()
        {
            while (true)
            {
                await ApplicationViewModel.GetCoins();

                await Task.Delay(60000);
            }
        }
        private async void AllCoins()
        {
            await ApplicationViewModel.GetAllCoins();
        }
    }
}
