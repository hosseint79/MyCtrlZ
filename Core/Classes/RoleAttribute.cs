//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc.Filters;
//namespace Core
//{
//    public class RoleAttribute : AuthorizeAttribute, IAuthorizationFilter
//    {
//        public void OnAuthorization(AuthorizationFilterContext context)
//        {
//            if (context.HttpContext.User.Identity.IsAuthenticated)
//            {

//            }
//            else
//            {
//                // go to login 
//            }
//        }
//    }
//}
