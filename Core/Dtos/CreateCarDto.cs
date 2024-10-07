using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class CreateCarDto
    {
        public int BrandId { get; set; }
        public string? ImageUrl { get; set; }
        public string Model { get; set; }
        public int EngineId { get; set; }
        public DateTime Year { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public string? Color { get; set; }
        public int? Hp { get; set; }
    }
}
