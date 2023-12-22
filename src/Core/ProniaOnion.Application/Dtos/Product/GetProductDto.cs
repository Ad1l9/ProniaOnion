using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Dtos.Product
{
    public record GetProductDto(int Id,string Name,decimal Price,string SKU,string? Description);
}
