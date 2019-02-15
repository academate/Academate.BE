﻿using CrossCuttingServices;
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



            if (!includeNotActive)
            {
                return await _dbContext.AcademicUnits
                    .Where(a => courseIds.Contains(a.CourseId) && a.Active == true)
                    .ToArrayAsync();
            }

            return await _dbContext.AcademicUnits
                .Where(a => courseIds.Contains(a.CourseId))
                .ToArrayAsync();
        }
    }
}