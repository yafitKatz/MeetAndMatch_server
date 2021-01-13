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
            using (Entities db = new Entities())
            {
                db.Participants.Add(Participant);
                db.SaveChanges();
            }
        }
        //Update
        public static void UpdateParticipant(Participant Participant)
        {
            using (Entities db = new Entities())
            {
                db.Entry(Participant).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Delete
        public static void DeleteParticipant(Participant Participant)
        {
            using (Entities db = new Entities())
            {
                db.Entry(Participant).State = EntityState.Deleted;
                db.Participants.Remove(Participant);
                db.SaveChanges();
            }
        }
        //GetById
        public static Participant GetParticipantById(int ParticipantId)
        {
            using (Entities db = new Entities())
            {
                return db.Participants.Where(i => i.id == ParticipantId).FirstOrDefault();
            }
        }
        //GetAll
        public static List<Participant> GetAllParticipants()
        {
            using (Entities db = new Entities())
            {
                return db.Participants.ToList();
            }
        }
    }
}
