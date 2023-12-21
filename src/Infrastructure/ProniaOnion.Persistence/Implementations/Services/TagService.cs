using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.Dtos.Tag;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;
        private readonly IMapper _mapper;

        public TagService(ITagRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetTagDto>> GetAllAsync(int page, int take)
        {
            ICollection<Tag> tags = await _repository.GetAllAsync(skip: (page - 1) * take, take: take, isTracking: false).ToListAsync();

            var tagdto = _mapper.Map<ICollection<GetTagDto>>(tags);
            return tagdto;
        }

        public async Task<GetTagDto> GetAysnc(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);

            if (tag is null) throw new Exception("Not found");

            return new GetTagDto(tag.Id, tag.Name);
        }

        public async Task CreateAsync(CreateTagDto createTagDTO)
        {
            await _repository.AddAsync(_mapper.Map<Tag>(createTagDTO));
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateTagDto tagDTO)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");

            tag.Name = tagDTO.Name;
            _repository.Update(tag);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Tag tag = await _repository.GetByIdAsync(id);
            if (tag is null) throw new Exception("Not found");

            _repository.Delete(tag);
            await _repository.SaveChangesAsync();
        }
    }
}
