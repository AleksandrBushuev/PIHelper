using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Client
{
    interface ISystemState
    {
        int State();
        string StateName();
    }

  

    public class SystemStateHelper {

        Dictionary<string, ISystemState> states = new Dictionary<string, ISystemState>()
        {
            { "Bad", new Bad() },
            { "I/O Timeout", new IOTimout() },
            { "No Data", new NoData() }
        };       

        public object GetValue(string value)
        {
            double dValue;
            if (double.TryParse(value, out dValue))
            {
                return dValue;
            }

            if (states.ContainsKey(value))
            {
                return states[value].StateName();
            }
            return null;
        }


    }


    public class Bad : ISystemState
    {
        public int State()
        {
            return 307;
        }

        public string StateName()
        {
            return "Bad";
        }
    }

    public class IOTimout : ISystemState
    {
        public int State()
        {
            return 247;
        }

        public string StateName()
        {
            return "I/O Timeout";
        }
    }

    public class NoData : ISystemState
    {
        public int State()
        {
            return 248;
        }

        public string StateName()
        {
            return "No Data";
        }
    }

}
