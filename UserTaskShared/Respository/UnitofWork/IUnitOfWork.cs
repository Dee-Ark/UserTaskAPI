using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskShared.Respository.Implementation;

namespace UserTaskShared.Respository.UnitofWork
{
    public interface IUnitOfWork
    {
        IStudentDetailsRepository StudentDetailsRepository { get; }
        ITeachersDetailsRepository TeachersDetailsRepository { get; }
        Task SaveAsync();
    }
}
