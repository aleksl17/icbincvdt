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
        /*public ApplicationUser user { get; set; }*/
        
        /*#nullable enable*/
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            /*#nullable disable*/
            if (id == null)
            {
                return NotFound();
            }

            /*user = await _um.Users
                .Include(u => u.FirstName)
                .Include(u => u.LastName)
                .Include(u => u.PhoneNumber)
                .Include(u => u.Address)
                .Include(u => u.ZipCode)
                .Include(u => u.City)
                .Include(u => u.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId);*/

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