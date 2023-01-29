using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.app.dal.Entities
{
    public class Applicant
    {
        public int Applicant_ID { get; set; } //(PK)
        public string Applicant_Name { get; set; }
        public string Applicant_Surname { get; set; }
        public DateTime Applicant_BirthDate { get; set; }
        public string Contact_Email { get; set; }
        public string Contact_Number { get; set; }
        public DateTime Applicant_CreationDate { get; set; }
        public DateTime Applicant_ModifiedDate { get; set; }

        //RELATIONSHIPS
        // An applicant can have many applications, they could apply every year and never get in
        // An Application though belongs to only 1 applicant at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
