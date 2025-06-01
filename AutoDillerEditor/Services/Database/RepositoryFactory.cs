using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services.Database
{
	/// <summary>
	/// Ленивая реализация фабрики репозиториев.
	/// Репозитории создаются только при первом обращении к ним.
	/// Это снижает нагрузку и увеличивает производительность, если не все репозитории используются одновременно.
	/// </summary>
	public class RepositoryFactory : IRepositoryFactory
	{
		private readonly AppDBContext _context;

		// Lazy обёртки для каждого репозитория
		private readonly Lazy<IUserRepository> _users;
		private readonly Lazy<IContractRepository> _contracts;
		private readonly Lazy<IAutomobileRepository> _automobiles;
		private readonly Lazy<IDealerRepository> _dealers;
		private readonly Lazy<IEquipmentRepository> _equipments;
		private readonly Lazy<IWarrantyRepository> _warranties;

		public RepositoryFactory(AppDBContext context)
		{
			_context = context;

			// Инициализация ленивых экземпляров — создаются только при первом вызове
			_users		 = new(() => new UserRepository(_context));
			_contracts	 = new(() => new ContractRepository(_context));
			_automobiles = new(() => new AutomobileRepository(_context));
			_dealers	 = new(() => new DealerRepository(_context));
			_equipments  = new(() => new EquipmentRepository(_context));
			_warranties  = new(() => new WarrantyRepository(_context));
		}

		/// <summary>Репозиторий пользователей</summary>
		public IUserRepository Users => _users.Value;

		/// <summary>Репозиторий контрактов</summary>
		public IContractRepository Contracts => _contracts.Value;

		/// <summary>Репозиторий автомобилей</summary>
		public IAutomobileRepository Automobiles => _automobiles.Value;

		/// <summary>Репозиторий дилеров</summary>
		public IDealerRepository Dealers => _dealers.Value;

		/// <summary>Репозиторий комплектаций</summary>
		public IEquipmentRepository Equipments => _equipments.Value;

		/// <summary>Репозиторий гарантий</summary>
		public IWarrantyRepository Warranties => _warranties.Value;
	}
}
