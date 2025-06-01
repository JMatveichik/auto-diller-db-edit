using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
	/// <summary>
	/// Обобщённая базовая ViewModel для работы с сущностями из БД.
	/// Содержит команды загрузки, добавления, редактирования и удаления.
	/// Используется с любыми сущностями и репозиториями.
	/// </summary>
	public abstract class DatabaseViewModelBase<TModel> : ViewModelBase
		where TModel : class
	{
		private IEnumerable<TModel> _items = Enumerable.Empty<TModel>();
		public IEnumerable<TModel> Items
		{
			get => _items;
			protected set => this.RaiseAndSetIfChanged(ref _items, value);
		}

		//public IEnumerable<TModel> Items { get; protected set; } = Enumerable.Empty<TModel>();

		[Reactive]
		public TModel? SelectedItem { get; set; }

		[Reactive]
		public bool IsLoading { get; protected set; }

		[Reactive]
		public string? ErrorMessage { get; protected set; }

		protected readonly IAutolandRepository<TModel> _repository;
		protected readonly IAppLoginStateService _loginState;

		public ReactiveCommand<Unit, Unit>	LoadCommand { get; private set; }
		public ReactiveCommand<Unit, Unit>	AddCommand { get; private set; }
		public ReactiveCommand<TModel, Unit> EditCommand { get; private set; }
		public ReactiveCommand<TModel, Unit> DeleteCommand { get; private set; }

		public DatabaseViewModelBase(
			IAutolandRepository<TModel> repository,
			IAppLoginStateService loginState) : base(loginState)
		{
			_repository = repository;
			_loginState = loginState;

			LoadCommand		= ReactiveCommand.CreateFromTask(LoadAsync);
			AddCommand		= ReactiveCommand.CreateFromTask(AddAsync);
			EditCommand		= ReactiveCommand.CreateFromTask<TModel>(EditAsync);
			DeleteCommand	= ReactiveCommand.CreateFromTask<TModel>(DeleteAsync);
		}

		protected virtual async Task LoadAsync()
		{
			await TryExecute(async () =>
			{
				Items = await _repository.GetAllAsync();
			});
		}

		protected async Task TryExecute(Func<Task> operation)
		{
			try
			{
				IsLoading = true;
				ErrorMessage = null;
				await operation();
			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}
			finally
			{
				IsLoading = false;
			}
		}

		// Абстрактные методы для специфичной логики (UI-диалоги)
		protected abstract Task<TModel?> ShowAddDialogAsync();
		protected abstract Task<bool> ShowEditDialogAsync(TModel model);
		protected abstract Task<bool> ShowDeleteConfirmAsync(TModel model);

		private async Task AddAsync()
		{
			var newItem = await ShowAddDialogAsync();
			if (newItem != null)
			{
				await _repository.CreateAsync(newItem);
				await LoadAsync();
			}
		}

		private async Task EditAsync(TModel model)
		{
			if (await ShowEditDialogAsync(model))
			{
				await _repository.UpdateAsync(model);
				await LoadAsync();
			}
		}

		private async Task DeleteAsync(TModel model)
		{
			if (await ShowDeleteConfirmAsync(model))
			{
				await _repository.DeleteAsync(model);
				await LoadAsync();
			}
		}
	}
}
