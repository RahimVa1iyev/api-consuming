using CourseApp.Core.Entities;
using CourseApp.Core.Repositories;
using CourseApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Data.Repositories
{
    public class GroupRepository : Repository<Group> , IGroupRepository
    {
        public GroupRepository(CourseDbContext context ) : base( context )
        {

        }
      
    }
}
