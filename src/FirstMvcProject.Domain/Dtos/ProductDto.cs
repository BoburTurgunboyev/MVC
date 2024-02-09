using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Domain.Dtos
{
    public class ProductDto
    {
        public string Title { get; set; }
        public int Quantiy { get; set; }
        public double Price { get; set; }
    }
}
