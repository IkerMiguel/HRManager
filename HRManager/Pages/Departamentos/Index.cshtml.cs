using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace HRManager.Pages.Departamentos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ManagerContext _context;

        public IndexModel(ManagerContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamentos { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Departamentos != null)
            {
                Departamentos = await _context.Departamentos.ToListAsync();
            }

        }
    }
}
