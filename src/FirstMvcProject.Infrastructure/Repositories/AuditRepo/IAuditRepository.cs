using FirstMvcProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Infrastructure.Repositories.AuditRepo
{
    public interface IAuditRepository
    {
        Task<ProductAuditViewModel> Index(DateTime? fromDate, DateTime? toDate, string name);
        Task<List<ProductAudit>> SortByUserName(string name);
        Task<List<ProductAudit>> GetFiltered(string? fromDate, string? toDate);
        Task<List<ProductAudit>> GetAllAudits();
    }
}
