using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace LikeApi
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            Console.WriteLine(context.Exception);
            //TODO: Log exception
            context.Result = new ObjectResult(new Response("Internal error"));
            return base.OnExceptionAsync(context);
        }
    }
}