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
    public class ParticipantBL
    {
        public static void AddParticipant(Participant1 p)
        {
            Participant newParticipant = Participant1.ToDal(p);
            ParticipantDL.AddParticipant(newParticipant);
        }

        public static void DeleteParticipant(Participant1 p)
        {
            Participant newParticipant = Participant1.ToDal(p);
            ParticipantDL.DeleteParticipant(newParticipant);
        }
        //Update
        public static void UpdateParticipant(Participant1 p)
        {
            Participant newParticipant = Participant1.ToDal(p);
            ParticipantDL.UpdateParticipant(newParticipant);
        }
        //GetById
        public static Participant1 GetParticipantById(int pId)
        {
            Participant newParticipant = ParticipantDL.GetParticipantById(pId);
            if (newParticipant != null)
                return new Participant1(newParticipant);
            else
                return null;
        }

        public static List<Participant1> GetAllParticipants()
        {
            List<Participant> lst = ParticipantDL.GetAllParticipants();
            return Dto.Participant1.ConvertToListDto(lst);
        }

        //GetAllAbandonedParticipants
        public static List<Participant1> GetAllAbandonedParticipants()
        {
            List<Meeting1> MeetingFromLastMonth = MeetingBL.GetMeetingFromLastMonth();

            List<Participant1> AbandonedParticipant = new List<Participant1>();
            foreach( Participant1 participant in GetAllParticipants())
            {
                bool isAbandoned = true;
                foreach (Meeting1 meeting  in MeetingFromLastMonth)
                    {
                        if(participant.id == meeting.firstParticipantId || participant.id == meeting.secondParticipantId)
                            {
                            isAbandoned = false;
                            break;
                            }
                    }
               if(isAbandoned)
               {
                   AbandonedParticipant.Add(participant);
               }
            }
            return AbandonedParticipant;
        }

        //SendEmail
        public static void SendEmail(string id, Meeting m)
        {
            List<Participant1> pList = new List<Participant1>();
            pList.Add(GetParticipantById((int)m.firstParticipantId));
            pList.Add(GetParticipantById((int)m.secondParticipantId));
            foreach(Participant1 p in pList)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("meetandmatch101@gmail.com");
                mail.To.Add(p.mail);
                //Test Mail - 1
                mail.Subject = "Meet&Match meeting details";
                mail.Body = "Dear " + p.firstName + "! \nOne of our matchmaker scheduled a new meeting for you.\nDate: " + m.date + "\nAddress: " + m.address;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("meetandmatch101@gmail.com", "katz2209");
                SmtpServer.EnableSsl = true;
                //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                //SmtpServer.PickupDirectoryLocation = @"C:\Users\Dell\Documents\mailout";
                try
                {
                    SmtpServer.Send(mail);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
