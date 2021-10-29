using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpringfieldUniversity.Data;
using SpringfieldUniversity.Models;

namespace SpringfieldUniversity.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SpringfieldUniversity.Data.SchoolContext _context;

        public IndexModel(SpringfieldUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get; set; }

        public IList<Course> Course { get;set; }

        public async Task OnGetAsync()
        {
            Course = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
