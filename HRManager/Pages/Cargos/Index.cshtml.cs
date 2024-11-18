using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace HRManager.Pages.Cargos
{
    public class IndexModel : PageModel
    {
        private readonly ManagerContext _context;

        public IndexModel(ManagerContext context)
        {
            _context = context;
        }

        public IList<Cargo> Cargos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cargos != null)
            {
                Cargos = await _context.Cargos.ToListAsync();
            }

        }
    }
}
