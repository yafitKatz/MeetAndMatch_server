using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Participant1
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<System.DateTime> dateOfBirth { get; set; }
        public string gender { get; set; }
        public Nullable<int> status { get; set; }
        public string origin { get; set; }
        public string resume { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }

        public Participant1()
        {

        }

        public Participant1(Dal.Participant p)
        {
            id = p.id;
            firstName = p.firstName;
            lastName = p.lastName;
            dateOfBirth = p.dateOfBirth;
            gender = p.gender;
            status = p.status;
            origin = p.origin;
            resume = p.resume;
            mail = p.mail;
            phone = p.phone;
        }


        public static List<Participant1> ConvertToListDto(List<Dal.Participant> lst)
        {
            return lst.Select(p => new Participant1(p)).ToList();
        }

        public static Dal.Participant ToDal(Participant1 p)
        {
            return new Dal.Participant
            {
                id = p.id,
                firstName = p.firstName,
                lastName = p.lastName,
                dateOfBirth = p.dateOfBirth,
                gender = p.gender,
                status = p.status,
                origin = p.origin,
                resume = p.resume,
                mail = p.mail,
                phone = p.phone
            
        };
        }
    }
}
