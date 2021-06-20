using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using XUCore.Net5.Template.Applaction.AdminUsers.Interfaces;
using XUCore.Net5.Template.Web.Models;

namespace XUCore.Net5.Template.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAdminLoginAppService adminLoginAppService;

        public HomeController(ILogger<HomeController> logger, IAdminLoginAppService adminLoginAppService)
        {
            _logger = logger;
            this.adminLoginAppService = adminLoginAppService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var res = await adminLoginAppService.Login(new Domain.Sys.AdminUser.AdminUserLoginCommand
            {
                Account = "admin",
                Password = "admin"
            }, CancellationToken.None);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
