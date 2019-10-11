using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using candyshop.Data;

namespace candyshop.Pages.CandyShop
{
    public class CreateModel : PageModel
    {
        private readonly candyshop.Data.ApplicationDbContext _context;

        public CreateModel(candyshop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cshop Cshop { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cshop.Add(Cshop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}