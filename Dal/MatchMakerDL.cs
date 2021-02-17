using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dal
{
    public class MatchMakerDL
    {

        //Login
        public static MatchMaker Login(string email, string pass)
        {
            try
            {
                using (MeetAndMatchEntities db = new MeetAndMatchEntities())
                {
                    //בדיקה אם קיים משתמש בעל כתובת מייל שהוכנסה
                    Dal.MatchMaker mm= db.MatchMakers.Where(m => m.mail == email).FirstOrDefault();
                    if (mm != null)
                        //אם כן- בדיקה אם הסיסמה תואמת
                        if (mm.password == pass && mm.isRegistered == true)
                            return mm;
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //GET UNAPPROVED LIST
        public static List<MatchMaker> GetUnapprovedMM(){
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                return db.MatchMakers.Where(mm => mm.isRegistered==false).ToList();
            }
        }

        //Add
        public static void AddMatchMaker(MatchMaker MatchMaker)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                db.MatchMakers.Add(MatchMaker);
                db.SaveChanges();
            }
        }

        //Update
        public static void UpdateMatchMaker(MatchMaker MatchMaker)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                db.Entry(MatchMaker).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Delete
        public static void DeleteMatchMaker(MatchMaker MatchMaker)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                db.Entry(MatchMaker).State = EntityState.Deleted;
                db.MatchMakers.Remove(MatchMaker);
                db.SaveChanges();
            }
        }

        //GetById
        public static MatchMaker GetMatchMakerById(int MatchMakerid)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                return db.MatchMakers.Where(i => i.matchMakerId == MatchMakerid).FirstOrDefault();
            }
        }
        //GetAll
        public static List<MatchMaker> GetAllMatchMakers()
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                return db.MatchMakers.ToList();
            }
        }

        //AproveMM
        public static void AproveMM(int mmId)
        {
            using (MeetAndMatchEntities db = new MeetAndMatchEntities())
            {
                MatchMaker mm = GetMatchMakerById(mmId);
                mm.isRegistered = true;
                UpdateMatchMaker(mm);
            }
        }
    }
}
