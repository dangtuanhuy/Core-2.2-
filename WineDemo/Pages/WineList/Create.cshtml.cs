using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WineDemo.Model;

namespace WineDemo.Pages.WineList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string Messaage { get; set; }
        [BindProperty]
        public Wine Wine { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _db.Wine.Add(Wine);
            await _db.SaveChangesAsync();
            Messaage = "Wine add success";
            return RedirectToPage("Index");
           
        }
    }
}