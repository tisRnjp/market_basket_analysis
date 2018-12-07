﻿using Major_Project.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Major_Project.App_Start
{
        public class ApplicationRoleManager : RoleManager<IdentityRole>
        {
            public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
                : base(roleStore) { }

            public static ApplicationRoleManager Create(
                IdentityFactoryOptions<ApplicationRoleManager> options,
                IOwinContext context)
            {
                var manager = new ApplicationRoleManager(
                    new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
                return manager;
            }
        }
}