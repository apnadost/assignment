using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Knorish.WebApplication.Models;
using Knorish.Service.Interfaces;
using Knorish.Infrastructure;
using Knorish.Dto;

namespace Knorish.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKnorishService _service;
        public HomeController(ILogger<HomeController> logger, IKnorishService service)
        {
            _logger = logger;
            _service = service;
        }

        public  ActionResult Index()
        {            
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> AddBoat(Boat boat)
        {
            CommonDto commonDto = new CommonDto();            
            commonDto=await _service.RegisterBoat(boat);            
            return Json(commonDto);
        }
        
        public async Task<JsonResult> GetBoatList()
        {
            return Json(await _service.GetBoatList());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Boat()
        {
            return View();
        }
        public IActionResult BoatBooking()
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
