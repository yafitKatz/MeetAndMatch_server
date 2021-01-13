using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Meeting1
    {
        public int id { get; set; }
        public Nullable<int> matchMakerId { get; set; }
        public Nullable<int> firstParticipantId { get; set; }
        public Nullable<int> secondParticipantId { get; set; }
        public string address { get; set; }
        public Nullable<System.DateTime> date { get; set; }


        public Meeting1()
        {

        }

        public Meeting1(Dal.Meeting m)
        {
            id = m.id;
            matchMakerId = m.matchMakerId;
            firstParticipantId = m.firstParticipantId;
            secondParticipantId = m.secondParticipantId;
            address = m.address;
            date = m.date;
        }

        public static List<Meeting1> ConvertToListDto(List<Dal.Meeting> lst)
        {
            return lst.Select(m => new Meeting1(m)).ToList();
        }

        public static Dal.Meeting ToDal(Meeting1 m)
        {
            return new Dal.Meeting
            {
                id = m.id,
                matchMakerId = m.matchMakerId,
                firstParticipantId = m.firstParticipantId,
                secondParticipantId = m.secondParticipantId,
                address = m.address,
                date = m.date
            };
        }

    }
}
