using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApparelStoreLibrary
{
    //public class ErrorFilter : ExceptionFilterAttribute
    //{
    //    public override void OnException(ExceptionContext context)
    //    {
    //        ViewDataDictionary dictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
    //        {

    //            Model = context.Exception.Message + "  " + context.Exception.GetType().ToString()
    //        };

    //        ViewResult vresult = new ViewResult()
    //        {
    //            ViewData = dictionary,
    //            ViewName = "ErrorView"
    //        };
    //        context.Result = vresult;

    //    }
    //}
}
