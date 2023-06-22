using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskShared.Model;
using UserTaskShared.Respository.Implementation;

namespace UserTaskShared.Respository
{
    public class TeachersDetailsRepository : RepositoryService<Teacher>, ITeachersDetailsRepository
    {
        public TeachersDetailsRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
