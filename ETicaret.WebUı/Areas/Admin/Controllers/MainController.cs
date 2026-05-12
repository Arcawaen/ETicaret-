using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Data;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class MainController : Controller
    {
        private readonly DatabaseContext _context;
        public MainController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.Include(o => o.AppUser).OrderByDescending(o => o.Id).ToListAsync();
            return View(orders);
        }
    }
}
