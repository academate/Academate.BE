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

        public async Task<IEnumerable<Exam>> GetExamsByIds(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return Enumerable.Empty<Exam>();

            var exams = await _dbContext.Exams.Where(c => ids.Contains(c.Id)).ToArrayAsync();
            return exams;
        }

    }
}
