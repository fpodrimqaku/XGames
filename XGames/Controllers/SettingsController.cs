using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using XGames.Configuration;

namespace XGames.Controllers
{

    public class SettingsController : Controller
    {
        private readonly SampleWebSettings _settings;

        public SettingsController(IOptions<SampleWebSettings> settingsOptions)
        {
            _settings = settingsOptions.Value;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = _settings.Title;
            ViewData["Updates"] = _settings.Updates;
            return View();
        }
    }
}