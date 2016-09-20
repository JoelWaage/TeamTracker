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

        public IActionResult Details(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Team team)
        {
            db.Teams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
