using CrossCuttingServices;
using Domain.DbContext;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Exams
{
    public class ExamRepository : IExamRepository
    {
        private readonly AcademateDbContext _dbContext;

        public ExamRepository(IDbProvider dbProvider)
        {
            _dbContext = dbProvider.Context;
        }

        public async Task<IEnumerable<Exam>> GetExamsByCourseIds(IEnumerable<int> courseIds)
        {
            if (courseIds == null || !courseIds.Any())
                return Enumerable.Empty<Exam>();

            var exams = await _dbContext.Exams
                .Where(e => courseIds.Contains(e.CourseId))
                .ToArrayAsync();

            return exams;
        }
    }
}
