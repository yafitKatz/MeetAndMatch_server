using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
using System.Net;
using System.Net.Mail;

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
            string sourceEmail="meetandmatch101@gmail.com";
            string destEmail="yafit22092000@gmail.com";
            string subject="Meet&Match Registeration";
            string body="Dear Matchmaker!\nUnfortunely, Meet&Match administor didn't approved your registeration";
            SendEmail("12345678",destEmail, sourceEmail, subject, body);
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
            string sourceEmail="meetandmatch101@gmail.com";
            string destEmail="yafit22092000@gmail.com";
            string subject="Meet&Match Registeration";
            string body="Dear Matchmaker!\nMeet&Match administor has approved your registeration";
            SendEmail("12345678",destEmail, sourceEmail, subject, body);
            return GetUnapprovedMM();
        }

        //SendEmail
        public static void SendEmail(string id, string destEmail, string sourceEmail, string subject, string body){
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(sourceEmail);
            mail.To.Add(destEmail);
            //Test Mail - 1
            mail.Subject = subject;
            mail.Body = body;
        
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential(sourceEmail, "katz2209");
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
