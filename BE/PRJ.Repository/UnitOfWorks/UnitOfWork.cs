namespace PRJ.Repository.UnitOfWorks;
public class UnitOfWork : IDisposable, IUnitOfWork
{
    private bool disposed = false;
    private readonly MainContext _context;
    public UnitOfWork(MainContext _context)
    {
        this._context = _context;
    }

    private IRepository<SHIPPER> _shipperRepo;
    
    public IRepository<SHIPPER> ShipperRepo
	{
		get
		{
			if (_shipperRepo == null)
			{
				_shipperRepo = new Repository<SHIPPER>(_context);
			}
			return _shipperRepo;
		}
	}

	public async Task<int> Save()
    {
        var res = await _context.SaveChangesAsync();
        return res;
    }

    public void Dispose()
    {
        this._context.Dispose();
    }
}
