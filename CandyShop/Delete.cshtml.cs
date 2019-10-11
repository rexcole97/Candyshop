using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using candyshop.Data;

namespace candyshop.Pages.CandyShop
{
    public class DeleteModel : PageModel
    {
        private readonly candyshop.Data.ApplicationDbContext _context;

        public DeleteModel(candyshop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cshop Cshop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cshop = await _context.Cshop.FirstOrDefaultAsync(m => m.CSID == id);

            if (Cshop == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cshop = await _context.Cshop.FindAsync(id);

            if (Cshop != null)
            {
                _context.Cshop.Remove(Cshop);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
