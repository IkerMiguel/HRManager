using HRManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Data
{
	public class ManagerContext : DbContext
	{
		public ManagerContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Empleado> Empleados { get; set; }
		public DbSet<Departamento> Departamentos { get; set; }
		public DbSet<Cargo> Cargos { get; set; }
		public DbSet<Nomina> Nominas { get; set; }
		public DbSet<Beneficio> Beneficios { get; set; }
	}
}
