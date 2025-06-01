using AutoLandProcessor.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	/// <summary>
	/// Обобщённый базовый класс репозитория для работы с сущностями.
	/// Предоставляет стандартные CRUD-методы (Create, Read, Update, Delete).
	/// Поддерживает повторное использование кода и единый доступ к DbContext.
	/// </summary>
	/// <typeparam name="T">Тип сущности</typeparam>
	public abstract class BaseRepository<T> where T : class
	{
		protected readonly AppDBContext _context;
		protected readonly DbSet<T>		_dbSet;

		/// <summary>
		/// Конструктор принимает AppDBContext через DI и инициализирует DbSet.
		/// </summary>
		public BaseRepository(AppDBContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		/// <summary>
		/// Получение всех записей из таблицы.
		/// </summary>
		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		/// <summary>
		/// Поиск сущности по первичному ключу (ID).
		/// </summary>
		public virtual async Task<T?> GetByIdAsync(int id)
		{
			return await _dbSet.FindAsync(id);
		}

		/// <summary>
		/// Добавление новой сущности в базу данных.
		/// </summary>
		public virtual async Task CreateAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Обновление существующей сущности.
		/// </summary>
		public virtual async Task UpdateAsync(T entity)
		{
			_dbSet.Update(entity);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Удаление сущности.
		/// </summary>
		public virtual async Task DeleteAsync(T entity)
		{
			_dbSet.Remove(entity);
			await _context.SaveChangesAsync();
		}
	}
}
