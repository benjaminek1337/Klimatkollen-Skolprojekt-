using System;
using Klimatkollen.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

//[assembly: HostingStartup(typeof(Klimatkollen.Areas.Identity.IdentityHostingStartup))]
//namespace Klimatkollen.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<KlimatkollenContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("KlimatkollenContextConnection")));

//                services.AddDefaultIdentity<IdentityUser>()
//                    .AddEntityFrameworkStores<KlimatkollenContext>();
//            });
//        }
//    }
//}