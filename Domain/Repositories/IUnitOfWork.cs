using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entropia_CS_React.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}