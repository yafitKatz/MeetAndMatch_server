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
        public static MatchMaker Login(int mmId, string pass)
        {
            try
            {
                using (Entities db = new Entities())
                {
                    //בדיקה אם קיים משתמש בעל כתובת מייל שהוכנסה
                    Dal.MatchMaker mm= db.MatchMakers.Where(m => m.matchMakerId== mmId).FirstOrDefault();
                    if (mm != null)
                        //אם כן- בדיקה אם הסיסמה תואמת
                        if (mm.password == pass)
                            return mm;
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Add
        public static void AddMatchMaker(MatchMaker MatchMaker)
        {
            using (Entities db = new Entities())
            {
                db.MatchMakers.Add(MatchMaker);
                db.SaveChanges();
            }
        }
        //Update
        public static void UpdateMatchMaker(MatchMaker MatchMaker)
        {
            using (Entities db = new Entities())
            {
                db.Entry(MatchMaker).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        //Delete
        public static void DeleteMatchMaker(MatchMaker MatchMaker)
        {
            using (Entities db = new Entities())
            {
                db.Entry(MatchMaker).State = EntityState.Deleted;
                db.MatchMakers.Remove(MatchMaker);
                db.SaveChanges();
            }
        }
        //GetById
        public static MatchMaker GetMatchMakerById(int MatchMakerid)
        {
            using (Entities db = new Entities())
            {
                return db.MatchMakers.Where(i => i.matchMakerId == MatchMakerid).FirstOrDefault();
            }
        }
        //GetAll
        public static List<MatchMaker> GetAllMatchMakers()
        {
            using (Entities db = new Entities())
            {
                return db.MatchMakers.ToList();
            }
        }

        //AproveMM
        public static void AproveMM(int mmId)
        {
            using (Entities db = new Entities())
            {
                MatchMaker mm = GetMatchMakerById(mmId);
                mm.isRegistered = true;
                UpdateMatchMaker(mm);
            }
        }
    }
}
