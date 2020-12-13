using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Data;
using icbincvdt.Models;

namespace icbincvdt.Pages.CVs
{
    public class DetailsModel : PageModel
    {
        private readonly icbincvdt.Data.CVContext _context;

        public DetailsModel(icbincvdt.Data.CVContext context)
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

            CV = await _context.CVs
                .Include(ed => ed.Educations)
                .Include(ex => ex.Experiences)
                .Include(sk => sk.Skills)
                .Include(re => re.References)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CVID == id);

            if (CV == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
