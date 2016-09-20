using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamTracker.Models;


namespace TeamTracker.Controllers
{
    public class TeamsController : Controller
    {
        private TeamTrackerContext db = new TeamTrackerContext();
        public IActionResult Index()
        {
            return View(db.Teams.ToList());
        }
    }
}
