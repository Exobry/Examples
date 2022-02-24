using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exobry.Examples.AD_GraphQL_EF.Application.Exceptions;

public class EntityNotFoundException : EntryPointNotFoundException
{
    public EntityNotFoundException(string message)
    :base(message)
    {
            
    }
}

