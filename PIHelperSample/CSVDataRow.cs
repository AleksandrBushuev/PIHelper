﻿using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIHelperSample
{
    public class CSVDataRow
    {          
        public string Value { get; set; }

        public DateTime Timestamp  { get; set; }
       
    }
}
