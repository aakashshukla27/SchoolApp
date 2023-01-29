using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.app.dal.Entities
{
    public class ApplicationStatus
    {
        public int ApplicationStatus_ID { get; set; } //(PK)
        public string ApplicationStatus_Name { get; set; }
        public DateTime ApplicationStatus_CreationDate { get; set; }
        public DateTime ApplicationtStatus_ModifiedDate { get; set; }

        //RELATIONSHIPS
        // An application status can be applied to mulitple applications
        // But Application can only have one application status at a time.
        public ICollection<Application> Applications { get; set; }
    }
}
