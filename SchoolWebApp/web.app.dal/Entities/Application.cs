using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.app.dal.Entities
{
    public class Application
    {
        public int Application_ID { get; set; } //(PK)
        public int Applicant_ID { get; set; } //(FK)
        public int Grade_ID { get; set; } //(FK)
        public int ApplicationStatus_ID { get; set; } //(FK)
        public DateTime Application_CreationDate { get; set; }
        public DateTime Application_ModifiedDate { get; set; }
        public int SchoolYear { get; set; }// THE YEAR THEY APPLYING TO START AT THE SCHOOL FOR

        //RELATIONSHIPS
        //Each Application belongs to a specific Applicant: Applicant_ID
        public Applicant Applicant { get; set; }

        //Each Application is applying for a specific Grade: Grade_ID
        public Grade Grade { get; set; }

        // Each Application is in one status at a time.
        // The status can be changed...
        // But it can only ever be linked to 1 at a time within an application: ApplicationStatus_ID
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
