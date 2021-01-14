using Microsoft.EntityFrameworkCore;
using TayFinitiv.Shared;

namespace TayFinitiv.Database
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<WithdrawRequest> Requests { get; set; }
		public DbSet<TellerMachine> ATMs { get; set; }
	}
}
