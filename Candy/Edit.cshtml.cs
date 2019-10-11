using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using candyshop.Data;

namespace candyshop.Pages.Candy
{
    public class EditModel : PageModel
    {
        private readonly candyshop.Data.ApplicationDbContext _context;

        public EditModel(candyshop.Data.ApplicationDbContext context)
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
           ViewData["CSID"] = new SelectList(_context.Set<Cshop>(), "CSID", "CSID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(candies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!candiesExists(candies.CID))
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

        private bool candiesExists(int id)
        {
            return _context.candies.Any(e => e.CID == id);
        }
    }
}
