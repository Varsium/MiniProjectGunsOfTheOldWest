using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GunsOfTheOldWest.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GunsOfTheOldWest.Models;

namespace GunsOfTheOldWest.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabase _database;

        public HomeController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var shooter = new Shooter {Bullets = _database.Bullets};
            return View(shooter);
        }

        [HttpPost]
        public IActionResult Shooting(int bullets)
        {
            if (bullets > 0)
            {
                _database.Bullets--;
            }
            else
            {
                return RedirectToAction("Reload");
            }

            if (CheckHit())
            {
                return RedirectToAction("GameWon", new { bullets });
            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GameWon( int bullets)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Summary(Shooter shooter)
        {
            if (shooter != null)
            {
                return View(shooter);
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Reload()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reload(int bullets)
        {
            _database.Bullets += bullets;
            return RedirectToAction("Index");
        }

        public int GenerateRandom()
        {
            var random = new Random();
            var randomnumber = random.Next(0, 11);
            return randomnumber;
        }

        public Boolean CheckHit()
        {
            if (GenerateRandom() < 4)
            {
                _database.GameWon = true;
                return true;
            }

            return false;
        }


    }
}
