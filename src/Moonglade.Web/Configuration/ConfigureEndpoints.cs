﻿using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Moonglade.Configuration;
using Moonglade.Utils;

namespace Moonglade.Web.Configuration
{
    public class ConfigureEndpoints
    {
        public static Action<IEndpointRouteBuilder> BlogEndpoints => endpoints =>
        {
            endpoints.MapGet("/ping", async context =>
            {
                var obj = new
                {
                    MoongladeVersion = Helper.AppVersion,
                    DotNetVersion = Environment.Version.ToString(),
                    EnvironmentTags = Helper.GetEnvironmentTags()
                };

                await context.Response.WriteAsync(obj.ToJson(), Encoding.UTF8);
            });
            endpoints.MapControllerRoute(
                "default",
                "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        };
    }
}
