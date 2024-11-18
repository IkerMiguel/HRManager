namespace HRManager.Models
{
	public class Departamento
	{
		public int Id { get; set; }
		public string NombreDepartamento { get; set; }
		public string Ubicacion { get; set; }
		public ICollection<Empleado>? Empleados { get; set; }
	}
}
