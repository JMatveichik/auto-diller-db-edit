using AutoLandProcessor.ViewModels;
using System.Windows;


namespace AutoLandProcessor.Views
{
    /// <summary>
    /// Interaction logic for ConfirmDialog.xaml
    /// </summary>
    internal partial class ConfirmDialog : Window
    {
        public ConfirmDialog(DialogMessageViewModel model)
        {
            InitializeComponent();
			DataContext = model;
        }

		private void OnButtonYesClick(object sender, RoutedEventArgs e)
		{
			DialogResult = true;
			Close();
		}

		private void OnButtonNoClick(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
			Close();
		}
	}
}
