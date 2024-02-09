using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Domain.Entities
{
    public class ProductAuditViewModel
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Name { get; set; }
        public List<ProductAudit>? FilteredLogs { get; set; }
    }
}
