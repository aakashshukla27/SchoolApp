using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Entities
{
    public class ApplicationStatus
    {
        public int ApplicationStatusId { get; set; }
        public string ApplicationStatusName { get; set; }
        public DateTime ApplicationStatusCreationDate { get; set; }
        public DateTime ApplicationStatusModifiedDate { get; set; }
        public ICollection<Application> Applications { get; set; }
    }
}
