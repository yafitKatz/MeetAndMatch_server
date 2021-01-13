using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class MatchMaker1
    {
        public int matchMakerId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public bool isRegistered { get; set; }

        public MatchMaker1()
        {

        }

        public MatchMaker1(Dal.MatchMaker mm)
        {
            matchMakerId = mm.matchMakerId;
            userName = mm.userName;
            password = mm.password;
            mail = mm.mail;
            phone = mm.phone;
            isRegistered = mm.isRegistered;
        }


        public static List<MatchMaker1> ConvertToListDto(List<Dal.MatchMaker> lst)
        {
            return lst.Select(mm => new MatchMaker1(mm)).ToList();
        }

        public static Dal.MatchMaker ToDal(MatchMaker1 mm)
        {
            return new Dal.MatchMaker
            {
                matchMakerId = mm.matchMakerId,
                userName = mm.userName,
                password = mm.password,
                mail = mm.mail,
                phone = mm.phone,
                isRegistered = mm.isRegistered
            };
        }
    }
}
