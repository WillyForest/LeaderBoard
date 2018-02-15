using LeaderBoard2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaderBoard2.Controllers
{
    public class HomeController : Controller
    {
        private LeaderBoardEntities db = new LeaderBoardEntities();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LeaderBoard()
        {
            return View();
        }

        public ActionResult PlayerSearch(DateTime date)
        {
            var players = db.Leaders.Where(p => p.Date_sc == date).ToList();
            if (players.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(players);
        }

    }
}