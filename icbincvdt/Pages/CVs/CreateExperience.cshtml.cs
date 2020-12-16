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
    public class CreateExperienceModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public CreateExperienceModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Experience Experience { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var emptyExperience = new Experience();
            
            if (await TryUpdateModelAsync<Experience>(
                emptyExperience,
                "Experience",
                e => e.CVID,
                e => e.ExperienceTitle,
                e => e.ExperienceText,
                e => e.ExperienceDateBegin,
                e => e.ExperienceDateEnd))
            {
                _context.Experiences.Add(emptyExperience);
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }
    }
}