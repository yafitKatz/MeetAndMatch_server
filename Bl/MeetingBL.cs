using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;

namespace Bl
{
    public class MeetingBL
    {
        public static void AddMeeting(Meeting1 m)
        {
            List<Meeting> duplicatedMeeting = MeetingDL.GetDuplicateMeeting(Meeting1.ToDal(m));
            if (duplicatedMeeting.Count() < 1 )
            {
                Meeting newMeeting = Meeting1.ToDal(m);
                MeetingDL.AddMeeting(newMeeting);
            }
            else
            {
                throw new InvalidOperationException("At least one participant is already attending another meeting on the date. please schedule on a different date.");
            }
        }

        public static void DeleteMeeting(Meeting1 m)
        {
            Meeting newMeeting = Meeting1.ToDal(m);
            MeetingDL.DeleteMeeting(newMeeting);
        }

        public static void DeleteParticipantsMeetings(Participant1 p)
        {
            List<Meeting1> lst = GetAllMeetings();
            foreach(Meeting1 m in lst)
            {
                if (m.firstParticipantId == p.id || m.secondParticipantId == p.id)
                    DeleteMeeting(m);
            }
        }

        //Update
        public static void UpdateMeeting(Meeting1 m)
        {
            Meeting newMeeting = Meeting1.ToDal(m);
            MeetingDL.UpdateMeeting(newMeeting);
        }
        //GetById
        public static Meeting1 GetMeetingById(int mId)
        {
            return new Meeting1(MeetingDL.GetMeetingById(mId));
        }

        public static List<Meeting1> GetAllMeetings()
        {
            List<Meeting> lst = MeetingDL.GetAllMeetings();
            return Dto.Meeting1.ConvertToListDto(lst);
        }

        public static List<Meeting1> GetMeetingsByMMID(int mmId)
        {
            List<Meeting> lst = MeetingDL.GetMeetingsByMMID(mmId);
            return Dto.Meeting1.ConvertToListDto(lst);
        }

        public static List<Meeting1> GetMeetingFromLastMonth()
        {
            List<Meeting> lst = MeetingDL.GetAllMeetings()
                                         .Where(m=> ((DateTime)m.date).Month ==  DateTime.Now.Month && ((DateTime)m.date).Year == DateTime.Now.Year)
                                         .ToList();
            return Dto.Meeting1.ConvertToListDto(lst);
        }

    }
}
