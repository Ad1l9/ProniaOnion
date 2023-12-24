using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Product;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductItemDto>> GetAllPaginatedAsync(int page,int take)
        {
            IEnumerable<ProductItemDto> dtos =_mapper.Map<IEnumerable<ProductItemDto>>(await _repository.GetAllAsync(skip: (page - 1) * take, take: take,isTracking:false).ToArrayAsync());
            return dtos;
        }

        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            Product product = await _repository.GetByIdAsync(id,includes:nameof(Product.Category));
            GetProductDto dto = _mapper.Map<GetProductDto>(product);
            return dto;
        }
    }
}
