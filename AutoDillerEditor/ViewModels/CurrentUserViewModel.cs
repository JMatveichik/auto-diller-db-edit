using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace AutoLandProcessor.ViewModels
{
	internal class CurrentUserViewModel : ViewModelBase
	{
		[Reactive]
		public string? FullName { get; private set; } = string.Empty;

		[Reactive]
		public string? Phone { get; private set; } = string.Empty;

		[Reactive]
		public string? Email { get; private set; } = string.Empty;

		[Reactive]
		public BitmapImage? Avatar {get ; private set;}

		public CurrentUserViewModel(IAppLoginStateService appLoginStateService) : base(appLoginStateService)
		{
		}

		protected override void UpdateUIForUser(User? user)
		{
			if (user != null)
			{
				FullName = $"{user.Name} {user.Surname}";
				Phone = user.Telephone;
				Email = user.Email;

				// Получаем директорию приложения
				string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
				string normalizedPath = user.Avatar.Replace('/', Path.DirectorySeparatorChar);
				// Комбинируем с относительным путём
				string imagePath = Path.Combine(appDirectory, normalizedPath);

				LoadImageAsync(imagePath);
			}
		}

		public async Task LoadImageAsync(string path)
		{
			Avatar = await Task.Run(() =>
			{
				var bitmap = new BitmapImage();
				bitmap.BeginInit();
				bitmap.UriSource = new Uri(path);
				bitmap.CacheOption = BitmapCacheOption.OnLoad;
				bitmap.EndInit();
				bitmap.Freeze(); // Для потокобезопасности
				return bitmap;
			});
		}
	}
}
