using System;
using Interlogica.Pastry.FrontEnd.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Interlogica.Pastry.FrontEnd.Areas.identity.IdentityHostingStartup))]
namespace Interlogica.Pastry.FrontEnd.Areas.identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("IdentityDbContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)

                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>();
            });
        }
    }
}