using AutoLandProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
	/// <summary>
	/// Интерфейс сервиса для управления состоянием аутентификации пользователя
	/// </summary>
	internal interface IAppLoginStateService
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
