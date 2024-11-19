using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Empleados
{
    public class EditModel : PageModel
    {
        private readonly ManagerContext _context;

        public EditModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;
        public List<Cargo> Cargos { get; set; } = new List<Cargo>();
        public List<Departamento> Departamentos { get; set; } = new List<Departamento>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }
            Cargos = await _context.Cargos.ToListAsync();
            Departamentos = await _context.Departamentos.ToListAsync();

            Empleado = empleado;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Cargos = await _context.Cargos.ToListAsync();
                Departamentos = await _context.Departamentos.ToListAsync();
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpleadoExists(int id)
        {
            return (_context.Empleados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
