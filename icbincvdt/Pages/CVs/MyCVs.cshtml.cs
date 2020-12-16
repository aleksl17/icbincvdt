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
    public class MyCVsModel : PageModel
    {
        private readonly icbincvdt.Data.ApplicationDbContext _context;

        public MyCVsModel(icbincvdt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CV> CV { get;set; }

        public async Task OnGetAsync()
        {
            CV = await _context.CVs.ToListAsync();
        }
    }
}