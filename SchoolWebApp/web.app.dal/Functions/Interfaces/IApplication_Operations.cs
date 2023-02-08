using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.app.dal.Entities;

namespace web.app.dal.Functions.Interfaces
{
    public interface IApplication_Operations
    {
        Task<Application> AddFullApplication(Int64 gradeId, Int64 applicationStatusId, Int32 schoolYear, string firstName, string surname, DateTime birthDate, string email, string contactNumber);

        Task<List<Application>> GetApplicationsByApplicantId(Int64 applicantId);
    }
}
