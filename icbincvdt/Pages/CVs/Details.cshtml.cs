using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCVContext _context;

        public DetailsModel(RazorPagesCVContext context)
        {
            _context = context;
        }

        public CV CV { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CV = await _context.CV.FirstOrDefaultAsync(m => m.ID == id);

            if (CV == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
