using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserTaskShared.Model;
using UserTaskShared.Respository.Implementation;
using UserTaskShared.Respository.UnitofWork;

namespace UserTaskShared.Respository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Dispose
        private bool _disposedValue = false;
        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing && _context != null)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
        
        public IStudentDetailsRepository StudentDetailsRepository => new StudentDetailsRepository(_context);
        public ITeachersDetailsRepository TeachersDetailsRepository => new TeachersDetailsRepository(_context);
        

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
