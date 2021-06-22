using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Http;
using NETCoreSandbox.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreSandbox.Attributes
{
    public class CustomEnableQueryAttribute : EnableQueryAttribute
    {
        private readonly DefaultQuerySettings defaultQuerySettings;
        public CustomEnableQueryAttribute()
        {
            defaultQuerySettings = new DefaultQuerySettings();            
            defaultQuerySettings.EnableExpand = true;
            defaultQuerySettings.EnableSelect = true;
        }
        public override void ValidateQuery(HttpRequest request, ODataQueryOptions queryOpts)
        {
            queryOpts.SelectExpand.Validator = new CustomExpandQueryValidator(defaultQuerySettings);
            // new Microsoft.AspNet.OData.Query.Validators.SelectExpandQueryValidator(this.defaultQuerySettings);
            //new MyExpandValidator();
            base.ValidateQuery(request, queryOpts);
        }
    }
}
