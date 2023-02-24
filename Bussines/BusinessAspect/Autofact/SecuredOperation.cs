using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;
using Core.Extensions;
using Bussines.Constants;

namespace Bussines.BusinessAspect.Autofact
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(",");  
            httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
           
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if(roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
