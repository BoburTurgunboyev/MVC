using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Domain.Entities
{
    public class ProductAudit
    {
        public int Id { get; set; }
        public string? Action { get; set; }
        public string? UserName { get; set; }
        public string? ControllerName { get; set; }
        public DateTime? DateTime { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
    }
}
