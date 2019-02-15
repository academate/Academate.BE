using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Enrollment
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Domain.Entities.Enrollment>> GetEnrollmentsOfUser(int userId);
    }
}