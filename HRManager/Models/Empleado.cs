using System.ComponentModel.DataAnnotations.Schema;

namespace HRManager.Models
{
	public class Empleado
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Email { get; set; }
		public string Telefono { get; set; }
		public DateTime FechaContratacion { get; set; }
		public int DepartamentoId { get; set; }
		public Departamento? Departamento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salario { get; set; }
        public int CargoId { get; set; }
		public Cargo? Cargo { get; set; }
		public ICollection<Nomina>? Nominas { get; set; }
	}
}
