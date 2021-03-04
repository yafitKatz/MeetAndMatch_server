using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;

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
                return new Participant1();
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
        
    }
}
