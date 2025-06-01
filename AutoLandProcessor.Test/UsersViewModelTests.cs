
using Moq;
using FluentAssertions;
using ReactiveUI.Testing;

using AutoLandProcessor.ViewModels;
using AutoLandProcessor.Services;
using AutoLandProcessor.Models;
using System.Reactive.Linq;
using ReactiveUI;
using System.Threading.Tasks;

namespace AutoLandProcessor.Test
{
	[TestFixture]
	public class UsersViewModelTests
	{
		private Mock<IRepositoryFactory>	_userRepoMock;
		private Mock<IUserDialogService>	_dialogServiceMock;
		private Mock<IAppLoginStateService> _loginStateMock;
		private UsersViewModel				_vm;

		// Test Items table
		private List<User> _testItems = new List<User>
		{
			new User { Id = 1, Role="user", Name = "John",	Surname = "Doe",		Email = "john@mail.test" },
			new User { Id = 2, Role="user",	Name = "Alice", Surname = "Davidson",	Email = "alice@mail.test" },
			new User { Id = 3, Role="admin", Name = "Bob",	Surname = "Johnson",	Email = "bob@mail.test" },
			new User { Id = 4, Role="user", Name = "Jane",	Surname = "Smith",		Email = "jane@mail.test" }
		};


		[SetUp]
		public void Setup()
		{
			_userRepoMock		= new Mock<IRepositoryFactory>();
			_dialogServiceMock	= new Mock<IUserDialogService>();
			_loginStateMock		= new Mock<IAppLoginStateService>();

			// 1. Настройка CurrentUser (простое свойство)
			_loginStateMock.SetupProperty(x => x.CurrentUser); // или SetupGet

			// 2. Настройка UserChanged (IObservable)
			_loginStateMock.Setup(x => x.UserChanged)
				.Returns(Observable.Never<User?>()); // или Observable.Return<User?>(null)

			// Настройка репозитория для LoadAsync
			_userRepoMock.Setup(x => x.Users.GetAllAsync())
				.ReturnsAsync(new List<User>());

			_vm = new UsersViewModel(
				_userRepoMock.Object,
				_dialogServiceMock.Object,
				_loginStateMock.Object
			);
		}

		/// <summary>
		/// Создание пустой модели (конструктор)
		/// </summary>
		[Test]
		public void Constructor_InitializesWithEmptyItems()
		{
			_vm.TextFilter.Should().BeEmpty();
			_vm.RoleFilter.Should().BeEmpty();
			_vm.SelectedItem.Should().BeNull();
			_vm.Items.Should().BeEmpty();

			UsersViewModel.AvailableRoles.Should().Equal("Admin", "User", "Employee");
		}


		[Test]
		public async Task WhenTextFilterChanges_FiltersItemsCorrectly()
		{
			//Arrange
			var filter = "John";
			var filtered = _testItems.Where(u =>
					(u.Name?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true) ||
					(u.Surname?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true) ||
					(u.Email?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true)).ToList();

			_userRepoMock.Setup(x => x.Users.FindAsync(filter, It.IsAny<string>())).ReturnsAsync(filtered);

			// Act
			_vm.TextFilter = filter;
			await Task.Delay(600); // Wait for Trottle

			// Assert
			_userRepoMock.Verify(x => x.Users.FindAsync(filter, It.IsAny<string>()), Times.Once);

			_vm.Items.Should().NotBeNull();
			Console.WriteLine($"Items count: {_vm.Items.Count()}");

			_vm.Items.Should().HaveCount(2);
			_vm.Items.Should().Contain(u => u.Name == "John");
			_vm.Items.Should().Contain(u => u.Surname == "Johnson");
			_vm.Items.Should().Contain(u => u.Email == "john@mail.test");
			_vm.Items.Should().NotContain(u => u.Name == "Alice");
			_vm.Items.Should().NotContain(u => u.Name == "Jane");
		}

		[Test]
		public async Task WhenTextFilterChanges_FiltersItemsEmpty()
		{
			//Arrange
			var filter = "AnyTestFilter";
			var filtered = _testItems.Where(u =>
					(u.Name?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true) ||
					(u.Surname?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true) ||
					(u.Email?.Contains(filter, StringComparison.OrdinalIgnoreCase) == true)).ToList();

			_userRepoMock.Setup(x => x.Users.FindAsync(filter, It.IsAny<string>())).ReturnsAsync(filtered);

			// Act
			_vm.TextFilter = filter;
			await Task.Delay(600); // Wait for Trottle

			// Assert
			_userRepoMock.Verify(x => x.Users.FindAsync(filter, It.IsAny<string>()), Times.Once);

			_vm.Items.Should().NotBeNull();
			_vm.Items.Should().HaveCount(0);
		}

		[Test]
		public async Task WhenRoleFilterChanges_FiltersItemsCorrectly()
		{
			//Arrange
			var filter = "user";
			var filtered = _testItems.Where(u => u.Role == filter).ToList();

			_userRepoMock.Setup(x => x.Users.FindAsync(It.IsAny<string>(), filter)).ReturnsAsync(filtered);

			// Act
			_vm.RoleFilter = filter;
			await Task.Delay(600); // Wait for Trottle

			// Assert
			_userRepoMock.Verify(x => x.Users.FindAsync(It.IsAny<string>(), filter), Times.Once);

			_vm.Items.Should().NotBeNull();
			_vm.Items.Should().HaveCount(3);
			_vm.Items.Should().Contain(u => u.Name == "John");
			_vm.Items.Should().Contain(u => u.Name == "Alice");
			_vm.Items.Should().Contain(u => u.Name == "Jane");
			_vm.Items.Should().NotContain(u => u.Name == "Bob");
		}

		[Test]
		public async Task WhenRoleFilterChanges_FiltersItemsEmpty()
		{
			//Arrange
			var filter = "WrongRole";
			var filtered = _testItems.Where(u => u.Role == filter).ToList();

			_userRepoMock.Setup(x => x.Users.FindAsync(It.IsAny<string>(), filter)).ReturnsAsync(filtered);

			// Act
			_vm.RoleFilter = filter;
			await Task.Delay(600); // Wait for Trottle

			// Assert
			_userRepoMock.Verify(x => x.Users.FindAsync(It.IsAny<string>(), filter), Times.Once);

			_vm.Items.Should().NotBeNull();
			_vm.Items.Should().HaveCount(0);
		}

		[Test]
		public async Task WhenRoleAndTextFilterChanges_FiltersItemsCorrectly()
		{
			//Arrange
			var roleFilter = "user";
			var textFilter = "John";

			var filtered = _testItems.Where(u =>
							(u.Role == roleFilter) &&
							(
								(u.Name?.Contains(textFilter, StringComparison.OrdinalIgnoreCase) == true) ||
								(u.Surname?.Contains(textFilter, StringComparison.OrdinalIgnoreCase) == true) ||
								(u.Email?.Contains(textFilter, StringComparison.OrdinalIgnoreCase) == true)
							)
						).ToList();

			_userRepoMock.Setup(x => x.Users.FindAsync(textFilter, roleFilter)).ReturnsAsync(filtered);

			// Act
			_vm.RoleFilter = roleFilter;
			_vm.TextFilter = textFilter;
			await Task.Delay(600); // Wait for Trottle

			// Assert
			_userRepoMock.Verify(x => x.Users.FindAsync(textFilter, roleFilter), Times.Once);

			_vm.Items.Should().NotBeNull();
			_vm.Items.Should().HaveCount(1);
			_vm.Items.Should().Contain(u => u.Name == "John" && u.Role == roleFilter);
		}

		[Test]
		public async Task WhenRoleAndTextFilterEmpty_FiltersItemsCorrectly()
		{
			//Arrange
			_userRepoMock.Setup(x => x.Users.FindAsync("", "")).ReturnsAsync(_testItems);

			// Act
			_vm.RoleFilter = "";
			_vm.TextFilter = "";
			await Task.Delay(600); // Wait for Trottle

			// Assert
			_userRepoMock.Verify(x => x.Users.FindAsync("", ""), Times.Once);

			_vm.Items.Should().NotBeNull();
			_vm.Items.Should().HaveCount(4);
		}

		[Test]
		public async Task AddUserCommand_WhenDialogReturnUser_AddUser()
		{
			// Arrange
			var newUser = new User { Id = 5, Name = "Test", Surname = "User", Email = "test@mail.test" };

			_dialogServiceMock.Setup(x => x.ShowAddNewUserDialog()).ReturnsAsync(newUser);

			_userRepoMock.Setup(x => x.Users.CreateAsync(newUser)).Returns(Task.CompletedTask);
			_userRepoMock.Setup(x => x.Users.GetAllAsync()).ReturnsAsync(new List<User> { newUser });

			// Act
			await _vm.AddCommand.Execute();

			// Assert
			_dialogServiceMock.Verify(x => x.ShowAddNewUserDialog(), Times.Once);
			_userRepoMock.Verify(x => x.Users.CreateAsync(newUser), Times.Once);
			_vm.Items.Should().Contain(newUser);
		}

		[Test]
		public async Task AddUserCommand_WhenDialogReturnNull_NotAddUser()
		{
			// Arrange
			User? user = null;
			_dialogServiceMock.Setup(x => x.ShowAddNewUserDialog()).ReturnsAsync(user);

			_userRepoMock.Setup(x => x.Users.CreateAsync(It.IsAny<User>())).Returns(Task.CompletedTask);
			_userRepoMock.Setup(x => x.Users.GetAllAsync()).ReturnsAsync(new List<User>() );

			// Act
			await _vm.AddCommand.Execute();

			// Assert
			_dialogServiceMock.Verify(x => x.ShowAddNewUserDialog(), Times.Once);
			_userRepoMock.Verify(x => x.Users.CreateAsync(It.IsAny<User>()), Times.Never);

			_vm.Items.Should().HaveCount(0);
		}

		[Test]
		public async Task EditUserCommand_WhenDialogReturnTrue_ModifyUser()
		{
			// Arrange
			var originalUser = new User { Id = 5, Name = "Test", Surname = "User", Email = "test@mail.test" };
			var updatedUser = new User { Id = 5, Name = "Updated", Surname = "User", Email = "updated@mail.test" };

			// Настройка моков:
			// 1. Диалог подтверждает редактирование (возвращает true)
			_dialogServiceMock.Setup(x => x.ShowEditUserDialog(originalUser))
							 .ReturnsAsync(true);

			// 2. Репозиторий обновляет пользователя
			_userRepoMock.Setup(x => x.Users.UpdateAsync(originalUser))
						.Returns(Task.CompletedTask)
						.Verifiable();

			// 3. После LoadAsync возвращаем обновлённого пользователя
			_userRepoMock.Setup(x => x.Users.GetAllAsync())
						.ReturnsAsync(new List<User> { updatedUser });

			// Активируем команду (передаём пользователя)
			await _vm.EditCommand.Execute(originalUser);

			// Assert
			// 1. Проверяем вызов диалога
			_dialogServiceMock.Verify(x => x.ShowEditUserDialog(originalUser), Times.Once);

			// 2. Проверяем вызов UpdateAsync с оригинальным пользователем
			_userRepoMock.Verify(x => x.Users.UpdateAsync(originalUser), Times.Once);

			// 3. Проверяем, что список пользователей обновился
			_vm.Items.Should().ContainSingle();
			_vm.Items.First().Should().BeEquivalentTo(updatedUser);

		}

		[Test]
		public async Task EditUserCommand_WhenDialogReturnFalse_NotModifyUser()
		{
			// Arrange
			var originalUser = new User { Id = 5, Name = "Test", Surname = "User", Email = "test@mail.test" };

			// 1. Настраиваем только необходимые моки:
			_dialogServiceMock.Setup(x => x.ShowEditUserDialog(originalUser))
							 .ReturnsAsync(false); // Пользователь отменил редактирование

			// 2. Явно указываем, что UpdateAsync не должен вызываться
			_userRepoMock.Setup(x => x.Users.UpdateAsync(It.IsAny<User>()))
						.Verifiable();

			// Act
			await _vm.EditCommand.Execute(originalUser);

			// Assert
			// 1. Проверяем вызов диалога
			_dialogServiceMock.Verify(x => x.ShowEditUserDialog(originalUser), Times.Once);

			// 2. Проверяем, что UpdateAsync не вызывался
			_userRepoMock.Verify(x => x.Users.UpdateAsync(It.IsAny<User>()), Times.Never);

			// 3. Проверяем, что список Items не изменился (остался пустым)
			_vm.Items.Should().BeEmpty();
		}

		[Test]
		public async Task DeletUserCommand_WhenDialogReturnTrue_RemoveUser()
		{
			// Arrange
			var originalUser = new User { Id = 5, Name = "Test", Surname = "User", Email = "test@mail.test" };

			// Настройка моков:
			// 1. Диалог подтверждает удаление пользователя (возвращает true)
			_dialogServiceMock.Setup(x => x.ShowDeleteUserDialog(originalUser))
							 .ReturnsAsync(true);

			// 2. Репозиторий удаляет пользователя
			_userRepoMock.Setup(x => x.Users.DeleteAsync(originalUser))
						.Returns(Task.CompletedTask)
						.Verifiable();

			// 3. После LoadAsync возвращаем пустой список
			_userRepoMock.Setup(x => x.Users.GetAllAsync())
						.ReturnsAsync(new List<User>());

			// Активируем команду (передаём пользователя)
			await _vm.DeleteCommand.Execute(originalUser);

			// Assert
			// 1. Проверяем вызов диалога
			_dialogServiceMock.Verify(x => x.ShowDeleteUserDialog(originalUser), Times.Once);

			// 2. Проверяем вызов DeleteAsync с оригинальным пользователем
			_userRepoMock.Verify(x => x.Users.DeleteAsync(originalUser), Times.Once);

			// 3. Проверяем, что список пользователей пустой
			_vm.Items.Should().BeEmpty();
		}

		[Test]
		public async Task DeletUserCommand_WhenDialogReturnFalse_NotRemoveUser()
		{
			// Arrange
			var originalUser = new User { Id = 5, Name = "Test", Surname = "User", Email = "test@mail.test" };

			// Настройка моков:
			// 1. Диалог подтверждает удаление пользователя (возвращает true)
			_dialogServiceMock.Setup(x => x.ShowDeleteUserDialog(originalUser))
							 .ReturnsAsync(false);

			// 2. Репозиторий удаляет пользователя
			_userRepoMock.Setup(x => x.Users.DeleteAsync(originalUser))
						.Returns(Task.CompletedTask)
						.Verifiable();

			// 3. После LoadAsync возвращаем пустой список
			_userRepoMock.Setup(x => x.Users.GetAllAsync())
						.ReturnsAsync(new List<User>());

			// Активируем команду (передаём пользователя)
			await _vm.DeleteCommand.Execute(originalUser);

			// Assert
			// 1. Проверяем вызов диалога
			_dialogServiceMock.Verify(x => x.ShowDeleteUserDialog(originalUser), Times.Once);

			// 2. Проверяем вызов DeleteAsync с оригинальным пользователем
			_userRepoMock.Verify(x => x.Users.DeleteAsync(originalUser), Times.Never);

			// 3. Проверяем, что список пользователей пустой
			_vm.Items.Should().BeEmpty();
		}
	}
}