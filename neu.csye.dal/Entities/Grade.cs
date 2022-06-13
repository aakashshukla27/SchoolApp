using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Entities
{
    public class Grade
    {
        public int GradeID { get; set; } //(PK)
        public string GradeName { get; set; }
        public int GradeNumber { get; set; }
        public int GradeCapacity { get; set; }
        public DateTime GradeCreationDate { get; set; }
        public DateTime GradeModifiedDate { get; set; }

        //RELATIONSHIPS
        // When an application is filled out, the applicant needs to specify what grade they applying for.
        // Therefore a grade is linked to multiple applications
        // But Application can only have one grade specified to them at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
