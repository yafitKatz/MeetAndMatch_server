using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;

namespace Bl
{
    public class MatchMakerBL
    {

        public static Dto.MatchMaker1 Login(int mmId, string pass)
        {
            var mm = Dal.MatchMakerDL.Login(mmId, pass);
            return new Dto.MatchMaker1(mm);
        }

        public static void AddMatchMaker(MatchMaker1 mm)
        {
            MatchMaker newMatchMaker = MatchMaker1.ToDal(mm);
            MatchMakerDL.AddMatchMaker(newMatchMaker);
        }

        public static void DeleteMatchMaker(MatchMaker1 mm)
        {
            MatchMaker newMatchMaker = MatchMaker1.ToDal(mm);
            MatchMakerDL.DeleteMatchMaker(newMatchMaker);
        }
        //Update
        public static void UpdateMatchMaker(MatchMaker1 mm)
        {
            MatchMaker newMatchMaker = MatchMaker1.ToDal(mm);
            MatchMakerDL.UpdateMatchMaker(newMatchMaker);
        }
        //GetById
        public static MatchMaker1 GetMatchMakerById(int mmId)
        {
            return new MatchMaker1(MatchMakerDL.GetMatchMakerById(mmId));
        }
    }
}
