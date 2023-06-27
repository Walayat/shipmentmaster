namespace PRJ.Repository.UnitOfWorks;
public interface IUnitOfWork
{
	IRepository<SHIPPER> ShipperRepo { get; }
	Task<int> Save();
}
