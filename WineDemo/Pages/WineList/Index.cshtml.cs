using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WineDemo.Model;

namespace WineDemo.Pages.WineList
{
    public class IndexModel : PageModel
    {
        public IEnumerable<Wine> Wines { get; set; }

        private readonly ApplicationDbContext _db;
        [TempData]
        public string  Messaage { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task OnGet()
        {
            Wines = await _db.Wine.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var wine = await _db.Wine.FindAsync(id);
            if(wine == null)
            {
                return NotFound();
            }
            _db.Wine.Remove(wine);
            await _db.SaveChangesAsync();
            Messaage = "Wine Delete successfully";
            return RedirectToPage("Index");

        }
    }
}