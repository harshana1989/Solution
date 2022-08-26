using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfases
{
    public interface IEntityMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
