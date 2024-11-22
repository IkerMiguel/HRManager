using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRManager.Pages.Departamentos
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
        public Departamento Departamento { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.Id == id);

            if (departamento == null)
            {
                return NotFound();
            }
            else
            {
                Departamento = departamento;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departamentos == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento != null)
            {
                Departamento = departamento;
                _context.Departamentos.Remove(departamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
