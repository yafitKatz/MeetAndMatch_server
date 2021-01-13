using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dal
{
    public class MeetingDL
    {
        //Add
        public static void AddMeeting(Meeting Meeting)
        {
            using (Entities db = new Entities())
            {
                db.Meetings.Add(Meeting);
                db.SaveChanges();
            }
        }
        //Update
        public static void UpdateMeeting(Meeting Meeting)
        {
            using (Entities db = new Entities())
            {
                db.Entry(Meeting).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Delete
        public static void DeleteMeeting(Meeting Meeting)
        {
            using (Entities db = new Entities())
            {
                db.Entry(Meeting).State = EntityState.Deleted;
                db.Meetings.Remove(Meeting);
                db.SaveChanges();
            }
        }
        //GetById
        public static Meeting GetMeetingById(int Meetingid)
        {
            using (Entities db = new Entities())
            {
                return db.Meetings.Where(i => i.id == Meetingid).FirstOrDefault();
            }
        }
        
        //GetAll
        public static List<Meeting> GetAllMeetings()
        {
            using (Entities db = new Entities())
            {
                return db.Meetings.ToList();
            }
        }

        //GetAllByMMID
        public static List<Meeting> GetMeetingsByMMID(int mmId)
        {
            using (Entities db = new Entities())
            {
                return db.Meetings.Where(m=> m.matchMakerId==mmId).ToList();
            }
        }

        //GetDuplicateMeeting
        public static List<Meeting> GetDuplicateMeeting(Meeting meeting)
        {
            using (Entities db = new Entities())
            {
                return db.Meetings.Where(m => m.date == meeting.date && (m.firstParticipantId == meeting.firstParticipantId || m.secondParticipantId == meeting.secondParticipantId)).ToList();
            }
        }
    }
}
