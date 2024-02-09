using FirstMvcProject.Domain.Entities;
using FirstMvcProject.Infrastructure.Data;
using FirstMvcProject.Infrastructure.Functions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Infrastructure.Repositories.AuditRepo
{
    public class AuditRepository:IAuditRepository
    {
        private readonly AppDbContext _context;

        public AuditRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductAudit>> GetAllAudits()
        {
            var auditLogs = await _context.ProductAudits.ToListAsync();
            return auditLogs;
        }

        public async Task<List<ProductAudit>> GetFiltered(string? fromDate, string? toDate)
        {
            var dateFormat = "dd.MM.yyyy";


            if (!DateTime.TryParseExact(fromDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var fromDateParsed))
            {
                if (fromDate != null)
                    throw new Exception("Invalid date format. fromDate For example : dd.mm.yyyy");
            }

            if (!DateTime.TryParseExact(toDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var toDateParsed))
            {
                if (toDate != null)
                    throw new Exception("Invalid date format. toDate For example : dd.mm.yyyy");
            }

            fromDateParsed = DateTime.SpecifyKind(fromDateParsed, DateTimeKind.Utc);
            toDateParsed = DateTime.SpecifyKind(toDateParsed, DateTimeKind.Utc);


            if (toDate != null)
            {
                if (fromDateParsed.Date > toDateParsed.Date)
                {
                    throw new Exception("To Date cannot be before From Date.");
                }
            }

            var auditLogs = await _context.ProductAudits
                .Where(log =>
                    (fromDateParsed == DateTime.MinValue || log.DateTime >= fromDateParsed) &&
                    (toDateParsed == DateTime.MinValue || log.DateTime <= toDateParsed))
                .ToListAsync();

            return auditLogs;
        }

        public async Task<ProductAuditViewModel> Index(DateTime? fromDate, DateTime? toDate, string name)
        {
            var auditLogs = await _context.ProductAudits.ToListAsync();

            var filteredLogs = ForAudit.FilterAuditLogsByDate(auditLogs, fromDate, toDate, name);

            var viewModel = new ProductAuditViewModel
            {
                FromDate = fromDate ?? DateTime.Today.AddDays(-100),
                ToDate = toDate ?? DateTime.Today,
                FilteredLogs = filteredLogs
            };

            return viewModel;
        }

        public async Task<List<ProductAudit>> SortByUserName(string name)
        {
            var auditLogs = _context.ProductAudits
             .AsEnumerable()
             .Where(log => log.UserName.Equals(name, StringComparison.OrdinalIgnoreCase))
             .ToList();

            return auditLogs;
        }
    }
}
