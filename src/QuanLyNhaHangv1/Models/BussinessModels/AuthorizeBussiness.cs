using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyNhaHangv1.Models.BussinessModels
{
    public class AuthorizeBussiness : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //if (HttpContext.Current.Session["userid"] == null)
            //{
            //    context.Result = new RedirectResult("/Admin/Home/Login?returnUrl=/Admin/" + context.ActionDescriptor.Co);
            //    return;

            //}
            //int userId = int.Parse(HttpContext.Current.Session["userid"].ToString());
            //ActionDescriptor action = context.ActionDescriptor;
            //string actionName = action..ControllerName
            base.OnActionExecuting(context);
        }
    }
}
