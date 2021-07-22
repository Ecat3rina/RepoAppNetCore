using RepoApp.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoApp.BLL.Repositories
{
    public class BaseRepository : IDisposable
    {
        protected readonly FirstContext _context;

        public BaseRepository(FirstContext context)
        {
            _context = context;
        }

        public virtual void Dispose()
        {
            this._context?.Dispose();
        }
    }
}
