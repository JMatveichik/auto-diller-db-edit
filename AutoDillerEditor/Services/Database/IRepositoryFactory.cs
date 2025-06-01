
namespace AutoLandProcessor.Services
{
	/// <summary>
	/// IRepositoryFactory — централизованный интерфейс для доступа к репозиториям.
	/// Позволяет легко управлять зависимостями и использовать только нужные репозитории.
	/// </summary>
	public interface IRepositoryFactory
	{
		IUserRepository Users { get; }
		IContractRepository Contracts { get; }
		IAutomobileRepository Automobiles { get; }
		IDealerRepository Dealers { get; }
		IEquipmentRepository Equipments { get; }
		IWarrantyRepository Warranties { get; }
	}
}
