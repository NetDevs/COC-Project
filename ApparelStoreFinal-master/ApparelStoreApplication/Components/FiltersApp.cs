using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreApplication.Components
{
    public class FiltersApp
    {
        public class ErrorFilter : ExceptionFilterAttribute
        {
            public override void OnException(ExceptionContext context)
            {
                ViewDataDictionary dictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                {

                    Model = context.Exception.Message + "  " + context.Exception.GetType().ToString()
                };

                ViewResult vresult = new ViewResult()
                {
                    ViewData = dictionary,
                    ViewName = "ErrorView"
                };
                context.Result = vresult;

            }
        }
    }
}
