using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using candyshop.Data;

namespace candyshop.Pages.Candy
{
    public class DeleteModel : PageModel
    {
        private readonly candyshop.Data.ApplicationDbContext _context;

        public DeleteModel(candyshop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public candies candies { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            candies = await _context.candies
                .Include(c => c.Candyshop).FirstOrDefaultAsync(m => m.CID == id);

            if (candies == null)
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

            candies = await _context.candies.FindAsync(id);

            if (candies != null)
            {
                _context.candies.Remove(candies);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
