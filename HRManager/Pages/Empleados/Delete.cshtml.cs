using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Empleados
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly ManagerContext _context;

        public DeleteModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }


            Empleado = await _context.Empleados
                .Include(p => p.Departamento)
                .Include(p => p.Cargo)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Empleado == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Empleados == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                Empleado = empleado;
                _context.Empleados.Remove(Empleado);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
