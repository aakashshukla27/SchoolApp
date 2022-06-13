using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Entities
{
    public class Application
    {
        public int ApplicationId { get; set; } // PK
        public int ApplicantId { get; set; } // FK
        public int GradeId { get; set; } // FK
        public int ApplicationStatusId { get; set; } // FK
        public DateTime ApplicationDate { get; set; }
        public DateTime ApplicationModifiedDate { get; set; }
        public int SchoolYear { get; set; }

        /// <summary>
        /// Each Application will belong to a specific applicant
        /// </summary>
        public Applicant Applicant { get; set; }

        /// <summary>
        /// Each application is applying for a specific grade
        /// </summary>
        public Grade Grade { get; set; }

        /// <summary>
        /// Each application will be in a status at a time
        /// </summary>
        public ApplicationStatus ApplicationStatus { get; set; }

    }
}
