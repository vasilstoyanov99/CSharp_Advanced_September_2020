using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _03.Oldest_Family_Member
{
    public class Family
    {
        public List<Person> members { get; set; }

        public Family()
        {
            members = new List<Person>();
        }
        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            return members.OrderByDescending(x => x.Age).FirstOrDefault();
        }

    }
}
