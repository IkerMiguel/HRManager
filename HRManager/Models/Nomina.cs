using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
	public class Nomina
	{
		public int Id { get; set; }
		public int EmpleadoId { get; set; }
		public Empleado? Empleado { get; set; }
		public DateTime PeriodoInicio { get; set; }
		public DateTime PeriodoFin { get; set; }
		[Column(TypeName = "decimal(6,2)")]
		public decimal TotalPagado { get; set; }
	}
}
