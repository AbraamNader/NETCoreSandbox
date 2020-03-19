using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Collection;

namespace NETCoreSandbox.DTO
{
    public class DataDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TranslationDTO> Translations { get; set; }
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
            CreateMap<Models.Translation, TranslationDTO>();
            //CreateMap<List<Models.Translation>, List<TranslationDTO>>();
            CreateMap<Models.Data, DataDTO>();
        }
    }
}
