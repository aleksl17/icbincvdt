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
    public class CreateSkillModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public CreateSkillModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public Skill Skill { get; set; }
        
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            return Page();
        }
        
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var emptySkill = new Skill();
            
            if (await TryUpdateModelAsync<Skill>(
                emptySkill,
                "Skill",
                e => e.CVID,
                e => e.SkillTitle,
                e => e.SkillText,
                e => e.SkillRating))
            {
                _context.Skills.Add(emptySkill);
                await _context.SaveChangesAsync();
                return RedirectToPage("./MyCVs");
            }

            return Page();
        }
    }
}