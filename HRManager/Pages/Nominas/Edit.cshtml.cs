using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Nominas
{
    public class EditModel : PageModel
    {
        private readonly ManagerContext _context;

        public EditModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomina Nomina { get; set; } = default!;
        public List<Empleado> Empleados { get; set; } = new List<Empleado>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nominas == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nominas.FirstOrDefaultAsync(m => m.Id == id);
            if (nomina == null)
            {
                return NotFound();
            }
            Empleados = await _context.Empleados.ToListAsync();

            Nomina = nomina;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Empleados = await _context.Empleados.ToListAsync();
                return Page();
            }

            _context.Attach(Nomina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NominaExists(Nomina.Id))
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

        private bool NominaExists(int id)
        {
            return (_context.Nominas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
