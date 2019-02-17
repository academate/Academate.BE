using CrossCuttingServices;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Course
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademateDbContext _dbContext;

        public CourseRepository(IDbProvider dbProvider)
        {
            _dbContext = dbProvider.Context;
        }

        public async Task<IEnumerable<AcademicUnit>> GetAcademicUnitsByCourseIds(IEnumerable<int> courseIds,
            bool includeNotActive = false)
        {
            if (courseIds == null || !courseIds.Any())
                return Enumerable.Empty<AcademicUnit>();

            var academicUnits = await _dbContext.AcademicUnits
                .Where(a => courseIds.Contains(a.CourseId))
                .ToArrayAsync();

            return includeNotActive ? academicUnits : academicUnits.Where(a => a.Active);
        }

        public async Task<IEnumerable<Domain.Entities.Course>> GetByIds(IEnumerable<int> courseIds)
        {
            if (courseIds == null || !courseIds.Any())
                return Enumerable.Empty<Domain.Entities.Course>();

            var course = await _dbContext.Courses
                .Where(c => courseIds.Contains(c.Id))
                .Include(c => c.Semester)
                .ToArrayAsync();

            return course;
        }
    }
}