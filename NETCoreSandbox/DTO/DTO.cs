using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Collection;
using NETCoreSandbox.Models;

namespace NETCoreSandbox.DTO
{
    public class DataDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TranslationDTO> Translations { get; set; }
    }

    public class LanguageDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class TranslationDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long LanguageId { get; set; }
        public long DataId { get; set; }
    }

    public class DataProfile : Profile
    {
        public DataProfile()
        {
            
            CreateMap<Translation, TranslationDTO>().ReverseMap();
            //CreateMap<List<Translation>, List<TranslationDTO>>().ReverseMap();
            //CreateMap<Data, DataDTO>().ForMember(x => x.Translations, options => options.ExplicitExpansion()).ReverseMap();
            CreateMap<Data, DataDTO>().ReverseMap();
        }
    }
}
