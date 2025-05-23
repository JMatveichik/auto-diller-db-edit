using ModernWpf.Controls;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoLandProcessor.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

			Loaded += delegate
			{
				UpdateAppTitle();
			};
		}


		void UpdateAppTitle()
		{
			//ensure the custom title bar does not overlap window caption controls
			Thickness currMargin = AppTitleBar.Margin;
			AppTitleBar.Margin = new Thickness(currMargin.Left, currMargin.Top, TitleBar.GetSystemOverlayRightInset(this), currMargin.Bottom);
		}
	}
}