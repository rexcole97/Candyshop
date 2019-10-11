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
    public class IndexModel : PageModel
    {
        private readonly candyshop.Data.ApplicationDbContext _context;

        public IndexModel(candyshop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<candies> candies { get;set; }

        public async Task OnGetAsync()
        {
            candies = await _context.candies
                .Include(c => c.Candyshop).ToListAsync();
        }
    }
}
