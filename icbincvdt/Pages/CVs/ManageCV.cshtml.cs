using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using icbincvdt.Data;
using icbincvdt.Models;
using Microsoft.AspNetCore.Identity;

namespace icbincvdt.Pages.CVs
{
    public class ManageCVModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _um;

        public ManageCVModel(icbincvdt.Data.ApplicationDbContext context, UserManager<ApplicationUser> um)
        {
            _context = context;
            _um = um;
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