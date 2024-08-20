using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLendingApplication.Mappers;
public interface IMapper<TSource, TResult>
{
    TResult Map(TSource map);
}
