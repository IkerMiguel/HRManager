using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Nominas
{
    public class DeleteModel : PageModel
    {
        private readonly ManagerContext _context;

        public DeleteModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Nomina Nomina { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nominas == null)
            {
                return NotFound();
            }


            Nomina = await _context.Nominas
                .Include(p => p.Empleado)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Nomina == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Nominas == null)
            {
                return NotFound();
            }
            var nomina = await _context.Nominas.FindAsync(id);
            if (nomina != null)
            {
                Nomina = nomina;
                _context.Nominas.Remove(Nomina);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
