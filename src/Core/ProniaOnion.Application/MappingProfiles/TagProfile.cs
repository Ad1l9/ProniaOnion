
using AutoMapper;
using ProniaOnion.Application.Dtos.Tag;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    public class TagProfile:Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, GetTagDto>().ReverseMap();
            CreateMap<CreateTagDto, Tag>();
        }
    }
}
