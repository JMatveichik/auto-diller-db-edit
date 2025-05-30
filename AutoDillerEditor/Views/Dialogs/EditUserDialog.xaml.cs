using System.Windows;
using AutoLandProcessor.Models;

namespace AutoLandProcessor.Views
{
    /// <summary>
    /// Interaction logic for EditUserDialog.xaml
    /// </summary>
    public partial class EditUserDialog : Window
    {
        public EditUserDialog(User user)
        {
            InitializeComponent();
            DataContext = user;
        }

		private void OnButtonSaveClick(object sender, RoutedEventArgs e)
		{
            DialogResult = true;
            Close();
		}

		private void OnButtonCancelClick(object sender, RoutedEventArgs e)
		{
            DialogResult = false;
            Close();
		}
	}
}
