using Microsoft.AspNet.OData.Query;
using Microsoft.AspNet.OData.Query.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETCoreSandbox.Validators
{
    public class CustomExpandQueryValidator : SelectExpandQueryValidator
    {
        public CustomExpandQueryValidator(DefaultQuerySettings defaultQuerySettings) : base(defaultQuerySettings)
        {
        }
        public override void Validate(SelectExpandQueryOption selectExpandQueryOption, ODataValidationSettings validationSettings)
        {
            if(string.IsNullOrEmpty(selectExpandQueryOption.RawExpand))
            {
                //validationSettings.
            }
            base.Validate(selectExpandQueryOption, validationSettings);
        }
    }
}
