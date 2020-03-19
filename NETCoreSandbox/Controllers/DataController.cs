using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCoreSandbox.Models;
using NETCoreSandbox.DTO;

namespace NETCoreSandbox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private DataContext DataContext;
        private IMapper Mapper;
        public DataController(DataContext dataContext, IMapper mapper)
        {
            DataContext = dataContext;
            Mapper = mapper;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Data> Get()
        {
            return DataContext.Data;
        }

        [HttpGet("ProjectTo")]
        [EnableQuery]
        public IQueryable<DataDTO> GetProjectTo()
        {
            return DataContext.Data.ProjectTo<DataDTO>(Mapper.ConfigurationProvider);
        }

        // https://localhost:44308/api/data/DTO?$expand=translations
        [HttpGet("DTO")]
        [EnableQuery]
        public IQueryable<DataDTO> GetDTO()
        {
            return DataContext.Data.Select(x => new DataDTO{
                Id = x.Id,
                Name = x.Name
            });
        }

        // https://localhost:44308/api/data/applyto?$expand=translations
        [HttpGet, Route("ApplyTo")]
        public IQueryable GetApplyTo(ODataQueryOptions<DataDTO> options)
        {
            var vmData = DataContext.Data.ProjectTo<DataDTO>(Mapper.ConfigurationProvider);
            var data = options.ApplyTo(vmData);
            var properties = Request.ODataFeature();
            return data;
            // ArgumentException: Expression of type 'System.Object' cannot be used for parameter of type 'System.String' of method 'NETCoreSandbox.DTO.TranslationDTO GetParameterValue[TranslationDTO](Microsoft.EntityFrameworkCore.Query.QueryContext, System.String)' (Parameter 'arg1')
        }
    }
}