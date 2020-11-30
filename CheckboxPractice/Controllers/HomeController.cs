using CheckboxPractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CheckboxPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            SetViewBagDtoAs();

            var vm = new TestViewModel
                     {
                         DtoBIds = new HashSet<int>()
                     };

            return View(vm);
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult PostIndex(TestViewModel vm)
        {
            SetViewBagDtoAs();

            return View("Index", vm);
        }

        private void SetViewBagDtoAs()
        {
            ViewBag.DtoAs = new[]
                            {
                                new DtoA
                                {
                                    Id   = 1,
                                    Name = "A1",
                                    DtoBs = new[]
                                            {
                                                new DtoB { Id = 11, Name = "B11" },
                                                new DtoB { Id = 12, Name = "B12" },
                                                new DtoB { Id = 13, Name = "B13" },
                                            }
                                },
                                new DtoA
                                {
                                    Id   = 2,
                                    Name = "A2",
                                    DtoBs = new[]
                                            {
                                                new DtoB { Id = 14, Name = "B14" },
                                                new DtoB { Id = 15, Name = "B15" },
                                                new DtoB { Id = 16, Name = "B16" },
                                            }
                                },
                            };
        }
    }

    public class TestViewModel
    {
        public HashSet<int> DtoBIds { get; set; }
    }

    public class DtoA
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DtoB[] DtoBs { get; set; }
    }

    public class DtoB
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
