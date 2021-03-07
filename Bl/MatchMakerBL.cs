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
        //Login
        public static Dto.MatchMaker1 Login(string email, string pass)
        {
            var mm = Dal.MatchMakerDL.Login(email, pass);
            if (mm != null)
                return new Dto.MatchMaker1(mm);
            else
                return null;
        }

        //Add
        public static void AddMatchMaker(MatchMaker1 mm)
        {
            MatchMaker newMatchMaker = MatchMaker1.ToDal(mm);
            MatchMakerDL.AddMatchMaker(newMatchMaker);
        }

        //Delete
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

        // GET UNAPPROVED MM
        public static List<MatchMaker1> GetUnapprovedMM()
        {
            List<MatchMaker> unaprrovedMMList= MatchMakerDL.GetUnapprovedMM();
            return Dto.MatchMaker1.ConvertToListDto(unaprrovedMMList);
        }

        //AproveMM
        public static List<MatchMaker1> AproveMM(int mmId)
        {
            MatchMakerDL.AproveMM(mmId);
            return GetUnapprovedMM();
        }
    }
}
