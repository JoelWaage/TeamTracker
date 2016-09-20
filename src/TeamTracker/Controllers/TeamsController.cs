using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamTracker.Models;
using Microsoft.EntityFrameworkCore;


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

        public IActionResult Edit(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            db.Entry(team).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            return View(thisTeam);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisTeam = db.Teams.FirstOrDefault(teams => teams.TeamId == id);
            db.Teams.Remove(thisTeam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
