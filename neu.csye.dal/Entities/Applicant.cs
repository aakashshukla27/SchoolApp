using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Entities
{
    public class Applicant
    {
        public int ApplicantId { get; set; } // PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //RELATIONSHIPS
        // An applicant can have many applications, they could apply every year and never get in
        // An Application though belongs to only 1 applicant at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
