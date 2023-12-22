using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Dtos.Category;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ICategoryService
    {
        Task<ICollection<GetCategoryDto>> GetAllAsync(int page, int take);
        Task<GetCategoryDto> GetAysnc(int id);

        Task CreateAsync(CreateCategoryDto createCategoryDto);

        Task UpdateAsync(int id, UpdateCategoryDto categoryDto);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }

}
