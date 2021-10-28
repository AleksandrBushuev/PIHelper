using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi.Client
{
    public class ValueData : IValueData
    {
        private object _value;
        private DateTime _timestamp;

        public ValueData(object value, DateTime timestamp)
        {
            _value = value;
            _timestamp = timestamp;
        }
        public DateTime GetTimestamp()
        {
            return _timestamp;
        }

        public object GetValue()
        {
            return _value;
        }
    }
}
