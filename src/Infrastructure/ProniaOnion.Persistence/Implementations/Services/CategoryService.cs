using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Category;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetCategoryDto>> GetAllAsync(int page, int take)
        {
            ICollection<Category> categories = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();

            var categoryDtos = _mapper.Map<ICollection<GetCategoryDto>>(categories);

            return categoryDtos;
        }

        public async Task<GetCategoryDto> GetAysnc(int id)
        {
            Category category = await _repository.GetByIdAsync(id);

            if (category is null) throw new Exception("Not found");

            return new GetCategoryDto(category.Id, category.Name) ;
        }

        public async Task CreateAsync(CreateCategoryDto createCategoryDTO)
        {
            Category category = _mapper.Map<Category>(createCategoryDTO);
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not found");

            category.Name = categoryDto.Name;
            _repository.Update(category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _repository.GetByIdAsync(id);
            if (category is null) throw new Exception("Not found");

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
        }
    }
}
