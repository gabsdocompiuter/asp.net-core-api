using RestApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services
{
    public class ServiceBase : IDisposable
    {
        protected Context _context;

        public ServiceBase(Context context)
        {
            _context = context;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _context.Dispose();
        }
    }
}
