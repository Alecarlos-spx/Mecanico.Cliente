﻿using AutoMecanica.ClienteApi.Host.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMecanica.ClienteApi.Host.Filters
{
    public class ErrorResponseFilter : IExceptionFilter
    {
 
            public void OnException(ExceptionContext context)
            {
                var errorResponse = ErrorResponse.From(context.Exception);
                context.Result = new ObjectResult(errorResponse) { StatusCode = 500 };
            }
       
    }
}

