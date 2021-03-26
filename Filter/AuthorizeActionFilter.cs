using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GettingStarted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GettingStarted.Filters
{
    public class AuthorizeActionFilter : IAuthorizationFilter
     {
         public static List<Role> roles = new List<Role>(){
            new Role(){RoleId=1,RoleName="Admin"}
           ,new Role(){RoleId=2,RoleName="User"}
        };
        readonly string _permission;
        public AuthorizeActionFilter(string permission)
        {
            _permission = permission ;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
         {
             var GetRoleId = context.HttpContext.Session.GetString("RoleId");
             if (String.IsNullOrEmpty(GetRoleId))
             {
                GetRoleId="-1";
             }
             Role  getRole = roles.SingleOrDefault(p => p.RoleId == Int32.Parse(GetRoleId));
             if (getRole==null)
             {
                 getRole = new Role(){RoleId=2,RoleName="User"};
             }
             if (_permission!=getRole.RoleName || getRole==null)
             {
                 context.Result = new ForbidResult();
             }
         }
     }
 } 