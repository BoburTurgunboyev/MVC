using FirstMvcProject.Infrastructure.Repositories.AuditRepo;
using Microsoft.AspNetCore.Mvc;

namespace FirstMvcProject.Web.Controllers
{
    public class AuditViewController : Controller
    {
        private readonly IAuditRepository _context;
        public AuditViewController(IAuditRepository context) => _context = context;
        public async Task<IActionResult> Index(DateTime? fromDate, DateTime? toDate, string Name) => View(await _context.Index(fromDate, toDate, Name));
    }
}
