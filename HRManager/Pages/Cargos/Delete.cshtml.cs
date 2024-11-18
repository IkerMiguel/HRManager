using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Cargos
{
    public class DeleteModel : PageModel
    {
        private readonly ManagerContext _context;

        public DeleteModel(ManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cargo Cargo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FirstOrDefaultAsync(m => m.Id == id);

            if (cargo == null)
            {
                return NotFound();
            }
            else
            {
                Cargo = cargo;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cargos == null)
            {
                return NotFound();
            }

            var cargo = await _context.Cargos.FindAsync(id);

            if (cargo != null)
            {
                Cargo = cargo;
                _context.Cargos.Remove(cargo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
