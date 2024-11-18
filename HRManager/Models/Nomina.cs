namespace HRManager.Models
{
	public class Nomina
	{
		public int IdNomina { get; set; }
		public int IdEmpleado { get; set; }
		public Empleado? Empleado { get; set; }
		public DateTime PeriodoInicio { get; set; }
		public DateTime PeriodoFin { get; set; }
		public decimal TotalPagado { get; set; }
	}
}
