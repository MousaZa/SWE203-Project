using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniProject.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace UniProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;

        public HomeController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books.Take(4).ToListAsync();
            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}