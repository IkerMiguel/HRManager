using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManager.Pages.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly ManagerContext _context;

        public CreateModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;
        public List<Cargo> Cargos { get; set; }
        public List<Departamento> Departamentos { get; set; }

        public void OnGet()
        {
            Cargos = _context.Cargos.ToList();
            Departamentos = _context.Departamentos.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Empleados == null || Empleado == null)
            {
                Cargos = _context.Cargos.ToList();
                Departamentos = _context.Departamentos.ToList();
                return Page();
            }

            _context.Empleados.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
