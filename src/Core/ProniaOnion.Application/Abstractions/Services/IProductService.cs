using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Application.Dtos.Category;
using ProniaOnion.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAllPaginatedAsync(int page, int take);


        Task<GetProductDto> GetByIdAsync(int id);
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(int id,UpdateProductDto dto);
    }
}
