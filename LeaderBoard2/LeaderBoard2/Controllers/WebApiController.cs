using LeaderBoard2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeaderBoard2.Controllers
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }

    public class WebApiController : ApiController
    {
        private LeaderBoardEntities db = new LeaderBoardEntities();

        public ICollection<Player> GetPlayer()
        {
            var players = (from Leader in db.Leaders select Leader).ToList();

            Collection<Player> p = new Collection<Player>();

            foreach (Leader l in players)
            {
                p.Add(new Player { Id = l.PlayerId, Name = l.Name, Score = l.Score });
            }
            return p;
        }
    }
}
