using HRManager.Data;
using HRManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRManager.Pages.Account
{
    public class RegisterModel : PageModel
    {
		private readonly ManagerContext _context;

		public RegisterModel(ManagerContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public User User { get; set; } = default!;

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Users == null || User == null)
			{
				return Page();
			}

			_context.Users.Add(User);
			await _context.SaveChangesAsync();

			return RedirectToPage("Login");
		}
	}
}
