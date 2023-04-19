using GQLDemo.Data;
using GQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GQLDemo.GraphQl
{
    
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Models.Platform> GetPlatforms([ScopedService] AppDbContext appDbContext)
        {
            return appDbContext.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommands([ScopedService] AppDbContext appDbContext)
        {
            return appDbContext.Commands;
        }
    }
}
