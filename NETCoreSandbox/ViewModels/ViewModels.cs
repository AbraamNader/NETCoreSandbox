using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Collection;

namespace NETCoreSandbox.ViewModels
{
    public class DataViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<TranslationViewModel> Translations { get; set; }
    }

    public class LanguageViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class TranslationViewModel
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
            CreateMap<Models.Translation, TranslationViewModel>();
            //CreateMap<List<Models.Translation>, List<TranslationViewModel>>();
            CreateMap<Models.Data, DataViewModel>();
        }
    }
}
