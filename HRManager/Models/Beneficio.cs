namespace HRManager.Models
{
	public class Beneficio
	{
		public int Id { get; set; }
		public string? Descripcion { get; set; }
		public decimal CostoEmpresa { get; set; }
		public decimal CostoEmpleado { get; set; }
	}
}
