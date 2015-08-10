using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Workflow.IdentityConfig))]
namespace Workflow
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app) { }

    }


}