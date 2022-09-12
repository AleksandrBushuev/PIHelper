using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.Data;
using OSIsoft.AF.PI;
using OSIsoft.AF.Time;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Pi.Client
{
    public class PIClient
    {
        PIServer _server;

        public bool IsConnected => isConnected();

        public bool Connect()
        {
            PIServers servers = new PIServers();
           _server= servers.DefaultPIServer;           
            _server.Connect();
            return isConnected();
        }

        public bool Connect(string serverName, string userName, string password)
        {
            _server = new PIServers()[serverName];

            NetworkCredential credential = GetCredential(userName, password);
            _server.Connect(credential, PIAuthenticationMode.PIUserAuthentication);
            return isConnected();
        }

        public PIPoint GetPoint(string pointName)
        {
            PIPoint point = PIPoint.FindPIPoint(_server, pointName);
            return point;
        }

        public IEnumerable<IValueData> GetValues(string tagName, DateTime startTime, DateTime endTime)
        {
            PIPoint tag = GetPoint(tagName);
            if (tag == null)
                throw new NullReferenceException($"PIPoint {tagName} not found");
            AFTimeRange timeRange = new AFTimeRange(new AFTime(startTime), new AFTime(endTime));

            IEnumerable<IValueData> values = tag.RecordedValues(timeRange, AFBoundaryType.Outside, null, false, int.MaxValue)
                .Select(value => new ValueData(value.Value, value.Timestamp));

            return values;

        }

        public int DeleteValues (string tagName, DateTime startTime, DateTime endTime)
        {
            PIPoint tag = GetPoint(tagName);
            if (tag == null)
                throw new NullReferenceException($"PIPoint {tagName} not found");

            AFTimeRange timeRange = new AFTimeRange(new AFTime(endTime), new AFTime(startTime));
            AFValues values = tag.RecordedValues(timeRange, AFBoundaryType.Outside, null, false, int.MaxValue);
                  
            AFErrors<AFValue> errors = tag.UpdateValues(values, AFUpdateOption.Replace);
            if (errors != null)
            {
                return values.Count() - errors.Errors.Count();
            }

            return values.Count();
        }

        public void UpdateValue(string pointName, object value, DateTime time)
        {
            PIPoint tag = GetPoint(pointName);
            if (tag == null)
                throw new NullReferenceException($"PIPoint {pointName} not found");

            AFValue afValue = GetAFValue(value, time);
            tag.UpdateValue(afValue, AFUpdateOption.Replace);

        }        

        public int ImportCsv(string tagName, IEnumerable<IValueData> values)
        {
            PIPoint tag = GetPoint(tagName);
            if (tag == null)
                throw new NullReferenceException($"PIPoint {tagName} not found");
            List<AFValue> data = new List<AFValue>();
            foreach (IValueData item in values)
            {
                AFValue value = GetAFValue(item.GetValue(), item.GetTimestamp().ToUniversalTime());
                data.Add(value);
            }
            AFErrors<AFValue> errors= tag.UpdateValues(data, AFUpdateOption.Replace);
            
            if (errors != null)
                return values.Count() - errors.Errors.Count();
            
            return values.Count();           
        }
       
        private AFValue GetAFValue(object value, DateTime time)
        {
            AFValue afValue = new AFValue(value, new AFTime(time));
            return afValue;
        }

        private NetworkCredential  GetCredential(string userName, string password)
        {         
            return new NetworkCredential(userName, password);
        }

        private bool isConnected()
        {
            if(_server!=null)
                 return _server.ConnectionInfo.IsConnected;
            return false;
        }
      
    }
}
