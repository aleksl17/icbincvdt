using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using icbincvdt.Data;
using icbincvdt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace icbincvdt.Pages.CVs
{
    [Authorize]
    public class CreateEducationModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public CreateEducationModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        
        [BindProperty]
        public CV CV { get; set; }

        [BindProperty]
        public Education Education { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CV = await _context.CVs.FirstOrDefaultAsync(e => e.CVID == id);

            if (CV == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var emptyEducation = new Education();

            if (await TryUpdateModelAsync<Education>(
                emptyEducation,
                "Education",
                e => e.CVID,
                e => e.EducationTitle,
                e => e.EducationText,
                e => e.EducationDateBegin,
                e => e.EducationDateEnd))
            {
                _context.Educations.Add(emptyEducation);
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }
    }
}