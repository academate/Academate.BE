using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Course
{
    public interface ICourseRepository
    {
        Task<IEnumerable<AcademicUnit>> GetAcademicUnitsByCourseIds(IEnumerable<int> courseIds, bool includeNotActive = false);
        Task<IEnumerable<Domain.Entities.Course>> GetByIds(IEnumerable<int> courseIds);
    }
}
