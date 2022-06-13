using neu.csye.dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace neu.csye.dal.Functions.Interfaces
{
    public interface IApplicationOperations
    {
        Task<Application> AddApplication(int gradeId, int applicationStatusId, int schoolYear, string firstName, string lastName,
            DateTime birthDate, string email, string contactNumber);
        Task<List<Application>> GetAllApplicationsByApplicantId(int applicantId);
    }
}
