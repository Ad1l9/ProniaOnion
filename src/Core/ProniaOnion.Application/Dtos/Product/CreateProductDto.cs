using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Dtos.Product
{
    public record CreateProductDto(string Name, decimal Price, string SKU, string? Description,int CategoryId,ICollection<int> ColorIds);
}
