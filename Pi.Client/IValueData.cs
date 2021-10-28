using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Client
{
    public interface IValueData
    {
        object GetValue();

        DateTime GetTimestamp();
    }
}
