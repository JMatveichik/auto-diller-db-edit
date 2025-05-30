using AutoLandProcessor.Models;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;



namespace AutoLandProcessor.Services
{
	/// <summary>
	/// Реализация сервиса состояния аутентификации с использованием реактивного подхода
	/// </summary>
	public class AppLoginStateService : IAppLoginStateService
	{
		/// <summary>
		/// BehaviorSubject - специальный тип Subject в Reactive Extensions, который:
		/// 1. Хранит текущее значение (в данном случае User или null)
		/// 2. При подписке сразу отправляет текущее значение подписчику
		/// 3. Рассылает новое значение всем подписчикам при изменении
		/// Инициализируется значением null (пользователь не авторизован)
		/// </summary>
		private readonly BehaviorSubject<User?> _currentUser = new(null);

		/// <summary>
		/// Текущий пользователь (реализация интерфейса)
		/// При получении значения возвращает текущее значение из BehaviorSubject
		/// При установке значения передает его в BehaviorSubject, который уведомляет всех подписчиков
		/// </summary>
		public User? CurrentUser
		{
			get => _currentUser.Value;  // Получаем текущее значение
			set => _currentUser.OnNext(value);  // Устанавливаем новое значение и уведомляем подписчиков
		}

		/// <summary>
		/// Наблюдаемый поток изменений пользователя (реализация интерфейса)
		/// Предоставляет возможность подписаться на изменения CurrentUser
		/// Возвращает интерфейс IObservable, скрывая реализацию через Subject
		/// </summary>
		public IObservable<User?> UserChanged => _currentUser.AsObservable();
	}
}

