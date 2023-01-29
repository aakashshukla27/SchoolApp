using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.app.dal.Entities
{
    public class Grade
    {
        public int Grade_ID { get; set; } //(PK)
        public string Grade_Name { get; set; }
        public int Grade_Number { get; set; }
        public int Grade_Capacity { get; set; }
        public DateTime Grade_CreationDate { get; set; }
        public DateTime Grade_ModifiedDate { get; set; }

        //RELATIONSHIPS
        // When an application is filled out, the applicant needs to specify what grade they applying for.
        // Therefore a grade is linked to multiple applications
        // But Application can only have one grade specified to them at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
