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

        [HttpPost]
        public ActionResult PlayerSearch(DateTime date)
        {
            var players = db.Leaders.Where(p => p.Date_sc == date).ToList();
            if (players.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(players);
        }

        
        public ActionResult GetDayTop()
        {
            ViewBag.Message = "за сегодня:";
            var players = db.Leaders.Where(p => p.Date_sc == DateTime.Today).ToList();
            if (players.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(players);
        }
        [HttpPost]
        public ActionResult GetDayTop(string type)
        {
            if (type == "day")
            {
                ViewBag.Message = "за сегодня:";
                var players = db.Leaders.Where(p => p.Date_sc == DateTime.Today).ToList();
                if (players.Count <= 0)
                {
                    return HttpNotFound();
                }
                return PartialView(players);
            }
            if (type == "week")
            {
                ViewBag.Message = "за неделю:";///TODO: week filter
                var players = db.Leaders.Where(p => p.Date_sc < DateTime.Today).ToList();
                if (players.Count <= 0)
                {
                    return HttpNotFound();
                }
                return PartialView(players);
            }
            if (type == "all")
            {
                ViewBag.Message = "за всё время:";
                var players = db.Leaders;
                return PartialView(players);
            }
            return HttpNotFound();
        }

    }
}