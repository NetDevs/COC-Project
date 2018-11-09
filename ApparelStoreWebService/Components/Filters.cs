﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApparelStoreWebService.Components
{
    public class ServiceErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
           context.Result = new ContentResult() { Content=context.Exception.Message };
        }
    }
}