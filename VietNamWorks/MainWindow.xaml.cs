using System.Windows;
using VietNamWorks.Data;
using VietNamWorks.Services;
using VietNamWorks.ViewModels;

namespace VietNamWorks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IGetJobService _getJobService = new GetJobService();
            JobContext context = new JobContext();
            this.DataContext = new MainViewModel(_getJobService, context);
        }
    }
}
