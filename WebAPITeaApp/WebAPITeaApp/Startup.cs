using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using WebAPITeaApp.Infrastructure;

[assembly: OwinStartup(typeof(WebAPITeaApp.Startup))]

namespace WebAPITeaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        // STEP 2 - ROLES AUTH - Assign the Role Manager Class to Owin Context
        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            //Rest of code is removed for brevity
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            //Rest of code is removed for brevity
        }
    }
}
