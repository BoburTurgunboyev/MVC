using FirstMvcProject.Domain.Entities;

namespace FirstMvcProject.Infrastructure.Functions
{
    public class ForAudit
    {
        public static List<ProductAudit> FilterAuditLogsByDate(List<ProductAudit> logs, DateTime? fromDate, DateTime? toDate, string Name)
        {
            var filteredLogs = logs
                .Where(log =>
                    (!fromDate.HasValue || log.DateTime >= fromDate) &&
                    (!toDate.HasValue || log.DateTime <= toDate?.AddDays(1)) &&
                    (Name == null || log.UserName.IndexOf(Name, StringComparison.OrdinalIgnoreCase) >= 0)
                )
                .ToList();
            return filteredLogs;
        }
    }
}
