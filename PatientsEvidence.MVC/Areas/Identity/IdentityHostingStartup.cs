using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientsEvidence.Primary.MVC.Areas.Identity.Data;

[assembly: HostingStartup(typeof(PatientsEvidence.Primary.MVC.Areas.Identity.IdentityHostingStartup))]
namespace PatientsEvidence.Primary.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PatientsEvidencePrimaryMVCContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PatientsEvidencePrimaryMVCContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PatientsEvidencePrimaryMVCContext>();
            });
        }
    }
}