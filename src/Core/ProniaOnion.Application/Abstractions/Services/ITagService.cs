using ProniaOnion.Application.Dtos.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ITagService
    {
        Task<ICollection<GetTagDto>> GetAllAsync(int page, int take);
        Task<GetTagDto> GetAysnc(int id);

        Task CreateAsync(CreateTagDto createTagDTO);

        Task UpdateAsync(int id, UpdateTagDto updateTagDTO);
        Task DeleteAsync(int id);
        Task SoftDeleteAsync(int id);
    }
}
