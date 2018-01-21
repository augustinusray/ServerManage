using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerManage.Filters
{
    public class CustomAuthorizeFilter : AuthorizeFilter
    {
        private static AuthorizationPolicy _policy_ = new AuthorizationPolicy
            (new[] { new DenyAnonymousAuthorizationRequirement() }, new string[] { });
  
          public CustomAuthorizeFilter() : base(_policy_) { }
  
          public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
          {
             await base.OnAuthorizationAsync(context);
             if (!context.HttpContext.User.Identity.IsAuthenticated ||
                 context.Filters.Any(item => item is IAllowAnonymousFilter))
                return;
             //do something
         }
}
}
