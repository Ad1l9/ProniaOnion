using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Product;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Implementations.Repositories;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _catrepository;
        private readonly IMapper _mapper;
        private readonly IColorRepository _colorRepository;

        public ProductService(IProductRepository repository, IMapper mapper, IColorRepository colorRepository, ICategoryRepository catrepository)
        {
            _repository = repository;
            _mapper = mapper;
            _colorRepository = colorRepository;
            _catrepository = catrepository;
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

        public async Task CreateAsync(CreateProductDto dto)
        {
            if (await _repository.IsExistAsync(p => p.Name == dto.Name)) throw new Exception("this product is already exist");

            if (!await _catrepository.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("dont");

            Product product = _mapper.Map<Product>(dto);
            product.ProductColors = new List<ProductColor>();
            foreach (var colorId in dto.ColorIds)
            {
                if (!await _colorRepository.IsExistAsync(c => c.Id == colorId)) throw new Exception("dont");
                product.ProductColors.Add(new ProductColor { ColorId = colorId });
            }
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id,UpdateProductDto dto)
        {
            Product existed = await _repository.GetByIdAsync(id, includes: nameof(Product.ProductColors));
            if (existed is null) throw new Exception("dont");

            if (dto.CategoryId != existed.CategoryId)
                if (!await _catrepository.IsExistAsync(c => c.Id == dto.CategoryId))
                    throw new Exception("dont");

            existed = _mapper.Map(dto, existed);
            existed.ProductColors = existed.ProductColors.Where(pc => dto.ColorIds.Any(colId => pc.ColorId == colId)).ToList();

            foreach (var cId in dto.ColorIds)
            {
                if (!await _colorRepository.IsExistAsync(c => c.Id == cId)) throw new Exception("dont");
                if (!existed.ProductColors.Any(pc => pc.ColorId == cId))
                {
                    existed.ProductColors.Add(new ProductColor { ColorId = cId });
                }
            }
            _repository.Update(existed);
            await _repository.SaveChangesAsync();
        }

    }
}
