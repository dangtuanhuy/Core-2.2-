using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineDemo.Model;

namespace WineDemo.Pages.WineList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string Messaage { get; set; }
        [BindProperty]
        public Wine Wine { get; set; }
        public async Task OnGet(int Id)
        {
            Wine = await _db.Wine.FindAsync(Id);
            //Wine = _db.Wine.Where(b => b.Id == Id).FirstOrDefault();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var WineFromDB = await _db.Wine.FindAsync(Wine.Id);
                WineFromDB.CategoryName = Wine.CategoryName;
                WineFromDB.ISBS = Wine.ISBS;
                WineFromDB.Publisher = Wine.Publisher;
                await _db.SaveChangesAsync();
                Messaage = "Edit success";
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}