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
            if (duplicatedMeeting == null)
            {
                Meeting newMeeting = Meeting1.ToDal(m);
                MeetingDL.AddMeeting(newMeeting);
            }
            else
            {
                throw Exception();
            }
        }

        public static void DeleteMeeting(Meeting1 m)
        {
            Meeting newMeeting = Meeting1.ToDal(m);
            MeetingDL.DeleteMeeting(newMeeting);
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
