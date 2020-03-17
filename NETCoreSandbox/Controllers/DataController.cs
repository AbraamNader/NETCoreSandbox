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
using NETCoreSandbox.ViewModels;

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

        [HttpGet("ViewModel")]
        [EnableQuery]
        public IQueryable<DataViewModel> GetViewModel()
        {
            return DataContext.Data.Select(x => new DataViewModel{
                Id = x.Id,
                Name = x.Name
            });
        }

        [HttpGet, Route("ApplyTo")]
        public IQueryable Get(ODataQueryOptions<DataViewModel> options)
        {
            var vmData = DataContext.Data.ProjectTo<DataViewModel>(Mapper.ConfigurationProvider);
            var data = options.ApplyTo(vmData);
            var properties = Request.ODataFeature();
            return data;
        }
    }
}