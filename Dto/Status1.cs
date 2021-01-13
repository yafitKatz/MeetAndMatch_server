using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Status1
    {
        public int statusNum { get; set; }
        public string statusDesc { get; set; }

        public Status1()
        {

        }

        public Status1(Dal.Status s)
        {
            statusNum = s.statusNum;
            statusDesc = s.statusDesc;
        }

        public static List<Status1> ConvertToListDto(List<Dal.Status> lst)
        {
            return lst.Select(s => new Status1(s)).ToList();
        }

        public static Dal.Status ToDal(Status1 s)
        {
            return new Dal.Status
            {
                statusNum = s.statusNum,
                statusDesc = s.statusDesc
        };
        }
    }

}
