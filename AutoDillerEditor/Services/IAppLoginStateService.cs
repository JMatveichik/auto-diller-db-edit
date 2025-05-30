using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	/// <summary>
	/// Интерфейс сервиса для управления состоянием аутентификации пользователя
	/// </summary>
	public interface IAppLoginStateService
	{
		/// <summary>
		/// Текущий авторизованный пользователь (null если не авторизован)
		/// </summary>
		User? CurrentUser { get; set; }

		/// <summary>
		/// Наблюдаемый поток изменений состояния пользователя
		/// Позволяет подписаться на изменения CurrentUser
		/// </summary>
		IObservable<User?> UserChanged { get; }
	}
}
