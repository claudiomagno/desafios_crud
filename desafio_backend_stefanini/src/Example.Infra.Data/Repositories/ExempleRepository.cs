using Example.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Infra.Data.Repositories
{
   public class ExempleRepository : GenericRepository<Domain.ExampleAggregate.Example>, IExempleRepository
    {
        public ExempleRepository(DbContext context) : base(context)
        {
        }
    }
}
