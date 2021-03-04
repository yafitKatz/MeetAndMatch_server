using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dal
{
    public class ParticipantDL
    {
        //Add
        public static void AddParticipant(Participant Participant)
        {
            try
            {
                using (MeetAndMatchEntities db = new MeetAndMatchEntities())
                {
                    db.Participants.Add(Participant);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                string s = "";
            }
        }
        //Update
        public static void UpdateParticipant(Participant Participant)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                db.Entry(Participant).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Delete
        public static void DeleteParticipant(Participant Participant)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                db.Entry(Participant).State = EntityState.Deleted;
                db.Participants.Remove(Participant);
                db.SaveChanges();
            }
        }
        //GetById
        public static Participant GetParticipantById(int ParticipantId)
        {
            try
            {
                using (MeetAndMatchEntities db = new MeetAndMatchEntities())
                {
                    return db.Participants.Where(i => i.id == ParticipantId).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        //GetAll
        public static List<Participant> GetAllParticipants()
        {
            try
            {
                using (MeetAndMatchEntities db = new MeetAndMatchEntities())
                {
                    return db.Participants.ToList();
                }
            }
            catch (Exception e)
            {

                return null;
            }
        }
    }
}
