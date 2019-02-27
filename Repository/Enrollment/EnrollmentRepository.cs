using CrossCuttingServices;
using Domain.DbContext;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Enrollment
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AcademateDbContext _dbContext;

        public EnrollmentRepository(IDbProvider dbProvider)
        {
            _dbContext = dbProvider.Context;
        }

        public async Task<IEnumerable<Domain.Entities.Enrollment>> GetEnrollmentsOfUser(int userId)
        {
            var enrollments = await _dbContext.Enrollments
                .AsNoTracking()
                .Where(e => e.StudentId == userId && e.Status == EnrollmentStatus.Active)
                .ToArrayAsync();

            return enrollments;
        }
    }
}
