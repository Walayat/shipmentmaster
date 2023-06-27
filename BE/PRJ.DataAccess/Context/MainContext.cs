using Microsoft.Extensions.Configuration;
using PRJ.DataAccess.Entities;

namespace PRJ.DataAccess.Context;

public class MainContext : DbContext
{
    public MainContext()
    {
	}

    public MainContext(DbContextOptions<MainContext> options) : base (options)
    {
    }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-7KU80TC;Initial Catalog=ShipmentMaster;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");
		}
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	}

	public virtual DbSet<SHIPPER> SHIPPERS { get; set; }
	public virtual DbSet<CARRIER> CARRIERS { get; set; }
	public virtual DbSet<SHIPMENT_RATE>  SHIPMENT_RATES { get; set; }
	public virtual DbSet<SHIPMENT> SHIPMENTS { get; set; }
}
