using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Holiday.Business.DataValue;

namespace Holiday.Business.DataAccess
{
    public interface ISourceGraber<T>
    {
        T GetSource();
    }
}
